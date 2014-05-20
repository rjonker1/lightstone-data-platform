namespace DataPlatform.Shared.Public.Entities
{
    public interface IDataField : IEntity, INamedEntity
    {
        IDataSource DataSource { get; set; }
    }
}