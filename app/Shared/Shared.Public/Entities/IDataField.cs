namespace DataPlatform.Shared.Public.Entities
{
    public interface IDataField : INamedEntity
    {
        IDataSource DataSource { get; set; }
    }
}