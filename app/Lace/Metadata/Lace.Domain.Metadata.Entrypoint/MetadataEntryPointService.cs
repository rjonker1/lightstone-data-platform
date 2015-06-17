using System.Collections.Generic;
using System.Collections.ObjectModel;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Metadata.EntryPoint;
using Lace.Domain.Metadata.EntryPoint.Builder.Factory;

namespace Lace.Domain.Metadata.Entrypoint
{
    public class MetadataEntryPointService : IEntryPoint
    {
        private IBuildSourceChain _buildSourceChain;
        private IBootstrap _bootstrap;
        private readonly IAdvancedBus _bus;

        public MetadataEntryPointService()
        {
            _bus = BusFactory.WorkflowBus();
        }

        public ICollection<IPointToLaceProvider> GetResponsesFromLace(ICollection<IPointToLaceRequest> request)
        {
            _buildSourceChain = new CreateSourceChain();
            _bootstrap = new Initialize(new Collection<IPointToLaceProvider>(), request, _bus, _buildSourceChain);
            _bootstrap.Execute();
            return _bootstrap.DataProviderResponses ?? EmptyResponse;
        }

        private static ICollection<IPointToLaceProvider> EmptyResponse
        {
            get
            {
                return new List<IPointToLaceProvider>();
            }
        }
    }

    public class BusFactory
    {

        public static IAdvancedBus WorkflowBus()
        {
            return Workflow.BuildingBlocks.BusFactory.CreateAdvancedBus("workflow/dataprovider/queue");
        }
    }
}
