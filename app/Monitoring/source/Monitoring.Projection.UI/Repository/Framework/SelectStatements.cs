namespace Monitoring.Projection.UI.Repository.Framework
{
    public static class SelectStatements
    {
        public const string GetMonitoringFromAllDataProviders =
            @"select top 100 Id, AggregateId,Payload, [Message],DataProviderId,DataProvider,Category,CategoryId,RequestAggregateId,Metadata,[Date],[TimeStamp]  from MonitoringDataProviders order by [TimeStamp] desc";
    }
}