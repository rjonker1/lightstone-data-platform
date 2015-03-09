namespace Workflow.Lace.Identifiers
{
    public class DataProviderIdentifier
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public DataProviderIdentifier()
        {
        }

        public DataProviderIdentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
