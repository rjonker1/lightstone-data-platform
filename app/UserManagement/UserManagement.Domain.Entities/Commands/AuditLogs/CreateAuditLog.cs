using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.AuditLogs
{
    public class CreateAuditLog : DomainCommand
    {
        public readonly Guid? UserId;
        public DateTime EventDateUtc;
        public readonly string EventType;
        public readonly string TableName;
        public readonly Guid RecordId;
        public readonly string ColumnName;
        public readonly string OriginalValue;
        public readonly string NewValue;
        public readonly string DataType;
        public readonly bool Revertable;
        public Guid? RevertedId;
        public Guid? CommitId;
        public int? CommitSequence;
        public int? CommitVersion;
        public readonly long CheckpointNumber;

        public ICollection<AuditLog> Auditlogs;
        public AuditLog AuditLogRoot;

        public CreateAuditLog(Guid? userId, DateTime eventdateutc, string eventtype, string tablename
            , Guid recordid, string columnname, string originalvalue, string newValue, string dataType
            ,bool revertable, Guid? revertedId, Guid? commitId, int? commitSequence, int? commitVersion, long checkpointNumber)
            
        {
            Id = Guid.NewGuid();
            UserId = userId;
            EventDateUtc = eventdateutc;
            EventType = eventtype;
            TableName = tablename;
            RecordId = recordid;
            ColumnName = columnname;
            OriginalValue = originalvalue;
            NewValue = newValue;
            DataType = dataType;
            Revertable = revertable;
            RevertedId = revertedId;
            CommitId = commitId;
            CommitSequence = commitSequence;
            CommitVersion = commitVersion;
            CheckpointNumber = checkpointNumber;
        }

    }
}
