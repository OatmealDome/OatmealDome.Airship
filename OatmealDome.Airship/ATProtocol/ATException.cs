namespace OatmealDome.Airship.ATProtocol;

public class ATException : Exception
{
    public ATError? Error
    {
        get;
        set;
    }
    
    public ATException() : base()
    {
        //
    }
    
    public ATException(string message) : base(message)
    {
        //
    }

    public ATException(ATError error) : base($"Server returned error {error.Error}")
    {
        Error = error;
    }
}
