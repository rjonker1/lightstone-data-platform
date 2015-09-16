namespace Lim.Enums
{
    public enum IntegrationType
    {
        Api = 1,
        Email = 2,
        FlatFile = 3,
        Notificaiton = 4,
        Ftp = 5
    }

    public enum IntegrationAction
    {
        Push = 1,
        Pull = 2
    }

    public enum AuthenticationType
    {
        None = 1,
        Basic = 2,
        Stateless = 3
    }
}
