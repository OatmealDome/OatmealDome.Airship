using OatmealDome.Airship.ATProtocol.Lexicon.Request;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class UploadBlobRequest : ATBytesProcedureRequest
{
    public override string NamespacedId => "com.atproto.repo.uploadBlob";
}
