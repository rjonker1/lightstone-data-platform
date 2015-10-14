using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class BmwFinanceResponse : IProvideDataFromBmwFinance
    {
        public BmwFinanceResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            Finances = Enumerable.Empty<IRespondWithBmwFinance>();
        }
     
        public static BmwFinanceResponse Empty()
        {
            return new BmwFinanceResponse();
        }

        private BmwFinanceResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            Finances = Enumerable.Empty<IRespondWithBmwFinance>();
        }

        public static BmwFinanceResponse WithState(DataProviderResponseState state)
        {
            return new BmwFinanceResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }
        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }

        public BmwFinanceResponse(IEnumerable<IRespondWithBmwFinance> finances)
        {
            Finances = finances;
        }

        [DataMember]
        public IAmBmwFinanceRequest Request { get; private set; }

        [DataMember]
        public IEnumerable<IRespondWithBmwFinance> Finances { get; private set; }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
        }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public bool Handled { get; private set; }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }
    }
}
