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
        public int Userid;
        public DateTime Eventdateutc;
        public string Eventtype;
        public string Tablename;
        public string Recordid;
        public string Columnname;
        public string Originalvalue;
        public string Newvalue;
        public string Datatype;
        public bool Revertable;
        public Guid? RevertedId;
        public Guid? CommitId;
        public int? CommitSequence;
        public int? CommitVersion;
        public long CheckpointNumber;

        public ICollection<Auditlog> Auditlogs;
        public Auditlog AuditlogRoot;

        public CreateAuditLog(int userId, DateTime eventdateutc, string eventtype, string tablename
            , string recordid, string columnname, string originalvalue, string newValue, string dataType
            ,bool revertable, Guid? commitId, int? commitSequence, int? commitVersion, long checkpointNumber)
            
        {
            Id = Guid.NewGuid();
            Userid = userId;
            Eventdateutc = eventdateutc;
            Eventtype = eventtype;
            Tablename = tablename;
            Recordid = recordid;
            Columnname = columnname;
            Originalvalue = originalvalue;
            Newvalue = newValue;
            Datatype = dataType;
            Revertable = revertable;
            CommitId = commitId;
            CommitSequence = commitSequence;
            CommitVersion = commitVersion;
            CheckpointNumber = checkpointNumber;
        }

    }
}
