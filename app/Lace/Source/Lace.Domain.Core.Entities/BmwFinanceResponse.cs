﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Finance;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class BmwFinanceResponse : IProvideDataFromBmwFinance
    {
        public BmwFinanceResponse()
        {
            Finances = Enumerable.Empty<IRespondWithBmwFinance>();
        }

        private BmwFinanceResponse(string message)
        {
            Finances = Enumerable.Empty<IRespondWithBmwFinance>();
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
        }
     
        public static BmwFinanceResponse Empty()
        {
            return new BmwFinanceResponse();
        }

        public static BmwFinanceResponse Failure(string message)
        {
            return new BmwFinanceResponse(message);
        }

        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }


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
