using System;

namespace Workflow.Transactions.Sender.Service.Views
{
    public class CommandCommitSequence
    {
        public Guid Id { get; set; }
        public int NextCommitSequence { get; set; }

        public static string SelectStatement()
        {
            return
                @"SELECT Id, MAX(CommitSequence) + 1 AS NextCommitSequence FROM CommandLog WHERE (Id = @RequestId) GROUP BY Id, CommitNumber, CommitSequence";

        }

        public static CommandCommitSequence NewSequence()
        {
            return new CommandCommitSequence() {NextCommitSequence = 1};
        }
    }
}
