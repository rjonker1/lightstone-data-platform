namespace Workflow.Lace.Identifiers
{
    public class ActionIdentifier
    {
        public int Id { get; private set; }
        public string Name { get; private set; }

        public ActionIdentifier(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
