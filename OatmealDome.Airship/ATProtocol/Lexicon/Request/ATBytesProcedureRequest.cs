using System.Net.Http.Headers;

namespace OatmealDome.Airship.ATProtocol.Lexicon.Request;

public abstract class ATBytesProcedureRequest : ATProcedureRequest
{
    public byte[] Data
    {
        get;
        set;
    }

    public string MimeType
    {
        get;
        set;
    }

    public override HttpContent? CreateHttpContent()
    {
        ByteArrayContent content = new ByteArrayContent(Data);

        content.Headers.ContentType = new MediaTypeHeaderValue(MimeType);

        return content;
    }
}
