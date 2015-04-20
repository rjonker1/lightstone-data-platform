namespace Monitoring.Dashboard.UI.Infrastructure.Repository
{
    public class SelectStatements
    {
        public const string GetDataProviderRequestResponses =
            "select top 100 * from MonitoringDataProvider where [action] = 'response' order by [date] desc";

        public const string GetCommitForRequestId =
            "select StreamIdOriginal, Payload, CommitSequence,[CommitStamp] from commits where StreamIdOriginal = @RequestId order by CommitSequence";

        public const string GetCommitForManyRequestId =
            "select StreamIdOriginal, Payload, CommitSequence,[CommitStamp] from commits where StreamIdOriginal in (@RequestIds) order by CommitSequence";
    }
}