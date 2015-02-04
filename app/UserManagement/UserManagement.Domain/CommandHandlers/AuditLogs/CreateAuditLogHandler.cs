using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities.Commands.AuditLogs;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.CommandHandlers.Audits
{
    public class CreateAuditLogHandler : AbstractMessageHandler<CreateAuditLog>
    {
        private readonly IRepository<Auditlog> _repository;

        public CreateAuditLogHandler(IRepository<Auditlog> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateAuditLog command)
        {
            _repository.Save(new Auditlog(command.Id, command.Userid, command.Eventdateutc, command.Eventtype, command.Tablename
            , command.Recordid, command.Columnname, command.Originalvalue, command.Newvalue, command.Datatype
            , command.Revertable, command.CommitId, command.CommitSequence, command.CommitVersion, command.CheckpointNumber));
        }
    }
}
