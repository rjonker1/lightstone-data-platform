using System;
using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Domain.Infrastructure.EntryPoint.Specification;

namespace Lace.Domain.Infrastructure.EntryPoint.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> SourceChain
        {
            get
            {
                return DataProviderSpecification.Chain();
            }
        }
    }
}