namespace DataPlatform.Shared.Public.Identifiers
{
    public class SystemIdentifier
    {
        public SystemIdentifier(string systemName)
        {
            SystemName = systemName;
        }

        public SystemIdentifier(string systemName, ServerIdentifier server)
        {
            SystemName = systemName;
            Server = server;
        }

        public string SystemName { get; private set; }
        public ServerIdentifier Server { get; private set; }

        public static SystemIdentifier CreateApi()
        {
            return new SystemIdentifier("API", ServerIdentifier.Create());
        }

    }
}