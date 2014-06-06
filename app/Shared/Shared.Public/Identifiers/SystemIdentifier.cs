namespace DataPlatform.Shared.Public.Identifiers
{
    public class SystemIdentifier
    {
        public SystemIdentifier(string systemName)
        {
            SystemName = systemName;
        }

        public string SystemName { get; private set; }

        public static SystemIdentifier CreateApi()
        {
            return new SystemIdentifier("API");
        }

        public static SystemIdentifier CreateLiveApp()
        {
            return new SystemIdentifier("LIVE Auto");
        }
    }
}