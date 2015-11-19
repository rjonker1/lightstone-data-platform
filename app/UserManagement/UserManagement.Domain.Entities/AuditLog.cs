using System;
using System.Collections.Generic;

namespace UserManagement.Domain.Entities
{
    public partial class AuditLog : Entity
    {
        public AuditLog()
        {
            
        }

        public AuditLog(Guid? commitId)
        {
            CommitId = commitId;
            this.AuditLogs = new HashSet<AuditLog>();
        }


        public AuditLog(Guid id, Guid? userId, DateTime eventdateutc, string eventtype, string tablename
            , Guid recordid, string columnname, string originalvalue, string newValue, string dataType
            ,bool revertable, Guid? revertedId, Guid? commitId, int? commitSequence, int? commitVersion, long checkpointNumber)
            : base(id)
        {
            //Id = id;
            UserId = userId;
            EventDateUtc = eventdateutc;
            EventType = eventtype;
            EntityName = tablename;
            RecordId = recordid;
            FieldName = columnname;
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

        //public Guid Id { get; set; }
        public virtual Guid? UserId { get; set; }
        public virtual DateTime EventDateUtc { get; set; }
        public virtual string EventType { get; set; }
        public virtual string EntityName { get; set; }
        public virtual Guid RecordId { get; set; }
        public virtual string FieldName { get; set; }
        public virtual string OriginalValue { get; set; }
        public virtual string NewValue { get; set; }
        public virtual string DataType { get; set; }
        public virtual bool Revertable { get; set; }
        public virtual Guid? RevertedId { get; set; }
        public virtual Guid? CommitId { get; set; }
        public virtual int? CommitSequence { get; set; }
        public virtual int? CommitVersion { get; set; }
        public virtual long CheckpointNumber { get; set; }

        public virtual ICollection<AuditLog> AuditLogs { get; set; }
        public virtual AuditLog AuditLogRoot { get; set; }
    }
}
