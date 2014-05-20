namespace DataPlatform.Shared.Public.Entities
{
    public interface INamedEntity
    {
        string Name { get; set; }
    }

    public abstract class NamedEntity : IEntity, INamedEntity
    {
        protected NamedEntity(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
        public int Id { get; set; }
    }
}
