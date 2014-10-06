using System;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Entities;
using Lace.DistributedServices.Events.Contracts;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Specification;

namespace Lace.Domain.Infrastructure.EntryPoint.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        private readonly IPackage _package;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public CreateSourceChain(IPackage package)
        {
            _package = package;
        }

        public void Build()
        {
            if (string.IsNullOrEmpty(_package.Action.Name))
            {
                Log.Error("Action for request is empty. Source chain cannot be built");
                throw new Exception("Action for request is empty");
            }

            Log.ErrorFormat("Building source chain for acton {0}", _package.Action.Name);

            SourceChain =
                new DataProviderSpecification().Specifications.SingleOrDefault(
                    w => w.Key.Equals(_package.Action.Name, StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        public Action<ILaceRequest, ILaceEvent, IProvideLaceResponse> SourceChain { get; private set; }
    }
}
