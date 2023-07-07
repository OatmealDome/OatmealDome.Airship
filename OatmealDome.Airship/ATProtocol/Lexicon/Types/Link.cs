using System.Text.Json.Serialization;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Types;

// https://atproto.com/specs/data-model#link
public sealed class Link
{
    [JsonPropertyName("$link")]
    public string Cid
    {
        get;
        set;
    }

    public Link()
    {
        Cid = "";
    }

    public Link(string cid)
    {
        Cid = cid;
    }
}
