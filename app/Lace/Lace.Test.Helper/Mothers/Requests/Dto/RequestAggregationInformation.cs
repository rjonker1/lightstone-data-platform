using System;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Test.Helper.Mothers.Requests.Dto
{
    public class AggregationInformation : IProvideRequestAggregation
    {
        public Guid AggregateId
        {
            get
            {
                return Guid.NewGuid();
            }
        }
    }

}
