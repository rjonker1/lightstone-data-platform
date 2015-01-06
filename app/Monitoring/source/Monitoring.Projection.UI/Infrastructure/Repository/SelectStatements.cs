namespace Monitoring.Projection.UI.Infrastructure.Repository
{
    public class SelectStatements
    {
        public const string GetEventsBySource =
            @"select AggregateId, Payload,[Source],[Date],[TimeStamp] from  Monitoring where [Source] = @Source";
    }
}