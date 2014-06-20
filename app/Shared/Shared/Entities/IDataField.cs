namespace DataPlatform.Shared.Entities
{
    public interface IDataField : INamedEntity
    {
        string Type { get; set; }
        IDataSource DataSource { get; set; }
    }
}