using System.Text.Json.Serialization;
using DotNext;
using DotNext.Text.Json;
using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class GetRecordRequest : ATQueryRequest
{
    public override string NamespacedId => "com.atproto.repo.getRecord";
    
    [ATQueryRequestParameterName("repo")]
    public string Repo
    {
        get;
        set;
    }

    [ATQueryRequestParameterName("collection")]
    public string Collection
    {
        get;
        set;
    }

    [ATQueryRequestParameterName("rkey")]
    public string RecordKey
    {
        get;
        set;
    }
    
    [ATQueryRequestParameterName("cid")]
    public Optional<string> Cid
    {
        get;
        set;
    }
}