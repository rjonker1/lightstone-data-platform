using System;
using Lim.Domain;
using Lim.Domain.Events;
using Toolbox.LIVE.Domain.Events;
using Toolbox.LIVE.Shared.Commands;

namespace Toolbox.LIVE.Domain
{
    public class ExecutedPackageIntegration : Aggregate
    {
        private Guid _id;
        public override Guid Id
        {
            get { return _id; }
        }

        private void Apply(LimEvent @event)
        {
            _id = @event.AggregateId;
        }

        public ExecutedPackageIntegration()
        {
            
        }

        public ExecutedPackageIntegration(SendExecutedPackage command)
        {
            ApplyChange(new ExecutedPackageSent(command.PackageId, command.UserId, command.ContractId, command.AccountNumber, command.RequestId,
                typeof (SendExecutedPackage), command.RequestId, command.EventType, command.EventTypeId, command.HasData, command.Payload, command.Username));
        }
    }
}