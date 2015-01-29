namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class SelectStatements
    {
        public const string GetEventsBySource =
            @"select AggregateId, Payload,[Source],[Date],[TimeStamp] from  Monitoring where AggregateId in (select top 5 AggregateId from Monitoring where Source = @Source  group by AggregateId order by max(Date) desc)";

        public const string GetEventBySourceAndId =
            @"select AggregateId, Payload,[Source],[Date],[TimeStamp] from  Monitoring where [Source] = @Source and AggregateId = @AggregateId";
    }
}