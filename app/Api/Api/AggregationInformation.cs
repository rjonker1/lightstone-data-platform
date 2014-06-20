using System;
using Lace.Request;

namespace Api
{
    public class AggregationInformation : IProvideRequestAggregation
    {
        public Guid AggregateId
        {
            get
            {
                return new Guid("1E660593-C11C-47B3-84DF-988F9FDFB0F1");
            }
        }
    }
}