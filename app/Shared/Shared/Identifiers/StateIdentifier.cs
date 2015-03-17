namespace DataPlatform.Shared.Identifiers
{
    public class StateIdentifier
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public StateIdentifier()
        {
        }

        public StateIdentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
