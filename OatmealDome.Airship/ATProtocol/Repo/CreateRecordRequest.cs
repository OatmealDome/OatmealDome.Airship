using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class CreateRecordRequest<T> : ATJsonProcedureRequest where T : ATRecord
{
    public override string NamespacedId => "com.atproto.repo.createRecord";

    [JsonPropertyName("repo")]
    public string Repo
    {
        get;
        set;
    }

    [JsonPropertyName("collection")]
    public string Collection
    {
        get;
        set;
    }

    [JsonPropertyName("rkey")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> RecordKey
    {
        get;
        set;
    }

    [JsonPropertyName("validate")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<bool> Validate
    {
        get;
        set;
    } = true;

    [JsonPropertyName("record")]
    public T Record
    {
        get;
        set;
    }
    
    [JsonPropertyName("swapCommit")]
    [JsonConverter(typeof(OptionalConverterFactory))]
    [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingDefault)]
    public Optional<string> SwapCommit
    {
        get;
        set;
    }
}
