using System;
using Lace.Request;

namespace Lace.Tests.Data.RequestData
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
