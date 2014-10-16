using System;
using LightstoneApp.Domain.Core;
using LightstoneApp.Domain.PackageBuilderModule.Entities;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Utils;

namespace LightstoneApp.Domain.PackageBuilderModule.Commands
{
    public class CreateNewPackageCommand : ValueObject<CreateNewPackageCommand>, ICommand, IDomainEvent, IMessageSessionProvider
    {
        private readonly Guid _iCommandId;

        public CreateNewPackageCommand()
        {
            _iCommandId = GuidUtil.NewSequentialId();

            Id = _iCommandId.ToString();
        }

        public CreateNewPackageCommand(Package package) : this()
        {
           // NewPackage = package.Clone<Package>();
        }

        public Package NewPackage { get; private set; }


        public string Id { get; private set; }

        public string AggregateId { get; private set; }
        public int AggregateVersion { get; private set; }
        public DateTimeOffset OccurredAt { get; private set; }
        string IMessageSessionProvider.SessionId
        {
            get { return this.SessionId; }
        }

        protected string SessionId
        {
            get { return "CreateNewPackage_" + NewPackage.Id; }
        }

        Guid ICommand.Id
        {
            get { return _iCommandId; }
        }
    }
}