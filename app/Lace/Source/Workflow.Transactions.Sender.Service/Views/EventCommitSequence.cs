using System;

namespace Workflow.Transactions.Sender.Service.Views
{
    public class EventCommitSequence
    {
        public Guid Id { get; set; }
        public int NextCommitSequence { get; set; }

        public static string SelectStatement()
        {
            return
                @"SELECT Id, MAX(CommitSequence) + 1 AS NextCommitSequence FROM DataProviderEventLog WHERE (Id = @RequestId) GROUP BY Id";

        }

        public static EventCommitSequence NewSequence()
        {
            return new EventCommitSequence() {NextCommitSequence = 1};
        }
    }
}
