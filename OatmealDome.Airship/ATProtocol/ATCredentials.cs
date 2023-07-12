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
}
