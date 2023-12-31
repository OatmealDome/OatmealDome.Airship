using OatmealDome.Airship.ATProtocol.Server;

namespace OatmealDome.Airship.ATProtocol;

public sealed class ATCredentials
{
    public string AccessJwt
    {
        get;
        set;
    }

    public string RefreshJwt
    {
        get;
        set;
    }

    public string Handle
    {
        get;
        set;
    }

    public string Did
    {
        get;
        set;
    }

    public ATCredentials()
    {
        //
    }

    internal ATCredentials(CreateAccountResponse accountResponse)
    {
        AccessJwt = accountResponse.AccessJwt;
        RefreshJwt = accountResponse.RefreshJwt;
        Handle = accountResponse.Handle;
        Did = accountResponse.Did;
    }
    
    internal ATCredentials(CreateSessionResponse sessionResponse)
    {
        AccessJwt = sessionResponse.AccessJwt;
        RefreshJwt = sessionResponse.RefreshJwt;
        Handle = sessionResponse.Handle;
        Did = sessionResponse.Did;
    }
    
    internal ATCredentials(RefreshSessionResponse refreshResponse)
    {
        AccessJwt = refreshResponse.AccessJwt;
        RefreshJwt = refreshResponse.RefreshJwt;
        Handle = refreshResponse.Handle;
        Did = refreshResponse.Did;
    }
}
