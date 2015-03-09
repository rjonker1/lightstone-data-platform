namespace DataPlatform.Shared.Identifiers
{
    public class DataProviderConnectionTypeIdentifier
    {
        public string Type { get; set; }
        public string Connection { get; set; }

        public DataProviderConnectionTypeIdentifier(string type, string source)
        {
            Type = type;
            Connection = source;
        }
    }
}
