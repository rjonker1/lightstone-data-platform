using System;
using System.Linq;
using Common.Logging;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Specification;
using Lace.Shared.Monitoring.Messages.Shared;
using PackageBuilder.Domain.Entities.Packages.WriteModels;

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
                Log.Error("Package Name for request is empty. Source chain cannot be built");
                throw new Exception("Action for request is empty");
            }

            Log.ErrorFormat("Building source chain for action {0}", _package.Action.Name);

            SourceChain =
                new DataProviderSpecification().Specifications.SingleOrDefault(
                    w => w.Key.Equals(_package.Action.Name, StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        public Action<ILaceRequest, ISendMonitoringMessages, IProvideResponseFromLaceDataProviders> SourceChain { get; private set; }
    }
}
