using OatmealDome.Airship.ATProtocol.Lexicon.Types;

namespace OatmealDome.Airship.ATProtocol.Repo;

public class ATReturnedRecord<T> where T : ATRecord
{
    public StrongRef Ref
    {
        get;
        set;
    }
    
    public T Value
    {
        get;
        set;
    }

    internal ATReturnedRecord(GetRecordResponse<T> response)
    {
        Ref = new StrongRef(response.Uri, response.Cid);
        Value = response.Value;
    }
}