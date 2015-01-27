using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class AggregationInformation : IProvideRequestAggregation
    {
        private readonly Guid _aggregateId;

        public AggregationInformation()
        {
            _aggregateId = Guid.NewGuid();
        }

        public Guid AggregateId
        {
            get { return _aggregateId; }
        }
    }

}
