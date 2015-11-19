using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.AuditLogs;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Domain.CommandHandlers.AuditLogs
{
    public class CreateAuditLogHandler : AbstractMessageHandler<CreateAuditLog>
    {
        private readonly IRepository<AuditLog> _repository;

        public CreateAuditLogHandler(IRepository<AuditLog> repository)
        {
            _repository = repository;
        }

        public override void Handle(CreateAuditLog command)
        {
            _repository.Save(new AuditLog(command.Id, command.UserId, command.EventDateUtc, command.EventType, command.TableName
            , command.RecordId, command.ColumnName, command.OriginalValue, command.NewValue, command.DataType
            , command.Revertable, command.RevertedId, command.CommitId, command.CommitSequence, command.CommitVersion, command.CheckpointNumber));
        }
    }
}
