using System.Net.Http.Headers;
using System.Text.Json;
using DotNext;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;
using OatmealDome.Airship.ATProtocol.Repo;
using OatmealDome.Airship.ATProtocol.Response;
using OatmealDome.Airship.ATProtocol.Server;

namespace OatmealDome.Airship.ATProtocol;

public class ATClient
{
    private static readonly HttpClient SharedClient = new HttpClient();
    
    private readonly HttpClient _httpClient;
    private readonly string _baseUrl;

    public ATCredentials? Credentials
    {
        get;
        set;
    }

    public ATClient(HttpClient httpClient, string baseUrl)
    {
        _httpClient = httpClient;
        _baseUrl = baseUrl;
    }

    public ATClient(string baseUrl) : this(SharedClient, baseUrl)
    {
        //
    }

    private async Task<HttpResponseMessage> SendRequestInternal(ATRequest request,
        ATAuthenticationType authenticationType)
    {
        string url = _baseUrl;

        if (!url.EndsWith('/'))
        {
            url += '/';
        }

        url += $"xrpc/{request.NamespacedId}";

        HttpRequestMessage requestMessage = new HttpRequestMessage(request.Method, url)
        {
            Content = request.CreateHttpContent()
        };

        if (authenticationType != ATAuthenticationType.None)
        {
            if (Credentials == null)
            {
                throw new ATException(
                    "Attempting to send authenticated request, but client is not currently authenticated");
            }

            string jwt = authenticationType == ATAuthenticationType.Bearer
                ? Credentials.AccessJwt
                : Credentials.RefreshJwt;

            requestMessage.Headers.Authorization = new AuthenticationHeaderValue("Bearer", jwt);
        }
        
        HttpResponseMessage responseMessage = await _httpClient.SendAsync(requestMessage);
        
        if (!responseMessage.IsSuccessStatusCode)
        {
            string response;
            
            try
            {
                response = await responseMessage.Content.ReadAsStringAsync();
            }
            catch (Exception)
            {
                throw new ATException(
                    $"Received HTTP status code {responseMessage.StatusCode}, failed to read response");
            }

            ATError? error;

            try
            {
                error = JsonSerializer.Deserialize<ATError>(response);

                if (error == null)
                {
                    // This is kinda disgusting.
                    throw new Exception();
                }
            }
            catch (Exception)
            {
                throw new ATException(
                    $"Received HTTP status code {responseMessage.StatusCode}, and an unknown response was returned: {response}");
            }

            throw new ATException(error);
        }

        return responseMessage;
    }

    protected async Task SendRequest(ATRequest request, ATAuthenticationType authenticationType)
    {
        using HttpResponseMessage message = await SendRequestInternal(request, authenticationType);
    }

    protected async Task<T> SendRequestWithJsonResponse<T>(ATRequest request, ATAuthenticationType authenticationType)
        where T : ATJsonResponse
    {
        using HttpResponseMessage message = await SendRequestInternal(request, authenticationType);

        string json = await message.Content.ReadAsStringAsync();

        return JsonSerializer.Deserialize<T>(json)!;
    }
    
    //
    // Server
    //

    public async Task<ATCredentials> Server_CreateAccount(string email, string handle, string password,
        string? inviteCode = null, string? recoveryKey = null)
    {
        CreateAccountRequest request = new CreateAccountRequest()
        {
            Email = email,
            Handle = handle,
            Password = password,
            InviteCode = inviteCode ?? Optional<string>.None,
            RecoveryKey = recoveryKey ?? Optional<string>.None
        };
        
        CreateAccountResponse response =
            await SendRequestWithJsonResponse<CreateAccountResponse>(request, ATAuthenticationType.None);

        Credentials = new ATCredentials(response);

        return Credentials;
    }

    public async Task<ATCredentials> Server_CreateSession(string identifier, string password)
    {
        CreateSessionRequest request = new CreateSessionRequest()
        {
            Identifier = identifier,
            Password = password
        };
        
        CreateSessionResponse response =
            await SendRequestWithJsonResponse<CreateSessionResponse>(request, ATAuthenticationType.None);

        Credentials = new ATCredentials(response);

        return Credentials;
    }

    public async Task<ATCredentials> Server_RefreshSession()
    {
        RefreshSessionResponse response =
            await SendRequestWithJsonResponse<RefreshSessionResponse>(new RefreshSessionRequest(),
                ATAuthenticationType.Refresh);

        Credentials = new ATCredentials(response);

        return Credentials;
    }

    public async Task Server_DeleteSession()
    {
        await SendRequest(new DeleteSessionRequest(), ATAuthenticationType.Refresh);
    }
    
    //
    // Repo
    //

    public async Task<CreateRecordResponse> Repo_CreateRecord<T>(string repo, string collection, T record,
        string? recordKey = null, bool? validate = null, string? swapCommit = null) where T : ATRecord
    {
        CreateRecordRequest<T> request = new CreateRecordRequest<T>()
        {
            Repo = repo,
            Collection = collection,
            Record = record,
            RecordKey = recordKey ?? Optional<string>.None,
            Validate = validate ?? true,
            SwapCommit = swapCommit ?? Optional<string>.None
        };

        CreateRecordResponse response =
            await SendRequestWithJsonResponse<CreateRecordResponse>(request, ATAuthenticationType.Bearer);

        return response;
    }
}
