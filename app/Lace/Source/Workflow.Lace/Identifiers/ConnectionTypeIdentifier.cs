namespace Workflow.Lace.Identifiers
{
    public class ConnectionTypeIdentifier
    {
        public string Type { get; set; }
        public string Connection { get; set; }

        public ConnectionTypeIdentifier(string type, string source)
        {
            Type = type;
            Connection = source;
        }

        public ConnectionTypeIdentifier()
        {
            
        }
    }
}
