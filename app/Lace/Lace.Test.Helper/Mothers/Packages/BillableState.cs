using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Test.Helper.Mothers.Packages
{
    public class BillableState : IBillStateIndicator
    {
        public BillableState(DataProviderNoRecordState state)
        {
            NoRecordState = state;
        }

        public DataProviderNoRecordState NoRecordState { get; private set; }
    }
}
