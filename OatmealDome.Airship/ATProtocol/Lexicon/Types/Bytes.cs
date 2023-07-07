using System.Text.Json.Serialization;
using OatmealDome.Airship.ATProtocol.Lexicon.Json;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Types;

// https://atproto.com/specs/data-model#bytes
[JsonConverter(typeof(BytesJsonConverter))]
public sealed class Bytes
{
    public byte[] Data
    {
        get;
        set;
    }

    public Bytes()
    {
        Data = Array.Empty<byte>();
    }

    public Bytes(byte[] data)
    {
        Data = data;
    }
}
