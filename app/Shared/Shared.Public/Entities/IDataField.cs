namespace DataPlatform.Shared.Public.Entities
{
    public interface IDataField : INamedEntity
    {
        string Type { get; set; }
        IDataSource DataSource { get; set; }
    }
}