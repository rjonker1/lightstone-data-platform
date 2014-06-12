using System;
using Lace.Request;

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
