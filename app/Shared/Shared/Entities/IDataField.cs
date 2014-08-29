namespace DataPlatform.Shared.Entities
{
    public interface IDataField : INamedEntity
    {
        string Type { get; }
        IDataSource DataSource { get; }
    }
}