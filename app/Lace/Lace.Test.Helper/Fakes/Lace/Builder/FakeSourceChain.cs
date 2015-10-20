using System;
using System.Collections.Generic;
using System.Linq;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceChain : IBuildSourceChain
    {
        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Build(ChainType chain)
        {
            return Chains.First(w => w.Key == chain).Value;
        }

        private static readonly
            IEnumerable<KeyValuePair<ChainType, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>>
            Chains = new List
                <KeyValuePair<ChainType, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>>
            {
                {
                    new KeyValuePair<ChainType, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>(
                        ChainType.All,
                        FakeSourceSpecification.Chain())
                },
                //{
                //    new KeyValuePair<ChainType, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>(
                //        ChainType.CarId,
                //        CarIdSpecification.Chain())
                //}
            };
    }
}
