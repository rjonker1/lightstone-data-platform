using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Specification;
using NServiceBus;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

namespace Lace.Domain.Infrastructure.EntryPoint.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        private readonly IPackage _package;
        private readonly ILog _log;

        public CreateSourceChain(IPackage package)
        {
            _log = LogManager.GetLogger(GetType());
            _package = package;
        }

        public void Build()
        {
            if (string.IsNullOrEmpty(_package.Action.Name))
            {
                _log.Error("Package Name for request is empty. Source chain cannot be built");
                throw new Exception("Action for request is empty");
            }

            _log.ErrorFormat("Building source chain for action {0}", _package.Action.Name);

            SourceChain =
                new DataProviderSpecification().Specifications.SingleOrDefault(
                    w => w.Key.Equals(_package.Action.Name, StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        public Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid> SourceChain
        {
            get;
            private set; }
    }
}