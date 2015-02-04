using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public partial class Auditlog : Entity
    {
        public Auditlog(Guid? commitId)
        {
            CommitId = commitId;
            this.Auditlogs = new HashSet<Auditlog>();
        }


        public Auditlog(Guid id, int userId, DateTime eventdateutc, string eventtype, string tablename
            , string recordid, string columnname, string originalvalue, string newValue, string dataType
            ,bool revertable, Guid? commitId, int? commitSequence, int? commitVersion, long checkpointNumber)
            : base(id)
        {
            Id = id;
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

        public Guid Id { get; set; }
        public int Userid { get; set; }
        public DateTime Eventdateutc { get; set; }
        public string Eventtype { get; set; }
        public string Tablename { get; set; }
        public string Recordid { get; set; }
        public string Columnname { get; set; }
        public string Originalvalue { get; set; }
        public string Newvalue { get; set; }
        public string Datatype { get; set; }
        public bool Revertable { get; set; }
        public Guid? RevertedId { get; set; }
        public Guid? CommitId { get; set; }
        public int? CommitSequence { get; set; }
        public int? CommitVersion { get; set; }
        public long CheckpointNumber { get; set; }

        public ICollection<Auditlog> Auditlogs { get; set; }
        public Auditlog AuditlogRoot { get; set; }
    }
}
