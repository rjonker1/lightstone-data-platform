﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [Serializable]
    [DataContract]
    public class LightstoneBusinessCompanyResponse : IProvideDataFromLightstoneBusinessCompany
    {
        public LightstoneBusinessCompanyResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            Companies = Enumerable.Empty<IProvideCompany>();
        }

        public static LightstoneBusinessCompanyResponse Empty()
        {
            return new LightstoneBusinessCompanyResponse();
        }

        public LightstoneBusinessCompanyResponse(IEnumerable<IProvideCompany> companies)
        {
            Companies = companies;
        }

        private LightstoneBusinessCompanyResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            Companies = Enumerable.Empty<IProvideCompany>();
        }

        public static LightstoneBusinessCompanyResponse WithState(DataProviderResponseState state)
        {
            return new LightstoneBusinessCompanyResponse(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        [DataMember]
        public DataProviderResponseState ResponseState { get; private set; }
        [DataMember]
        public string ResponseStateMessage { get { return ResponseState.Description(); } }

        [DataMember]
        public IEnumerable<IProvideCompany> Companies { get; private set; }

        [DataMember]
        public Type Type
        {
            get { return GetType(); }
        }

        [DataMember]
        public string TypeName
        {
            get { return GetType().Name; }
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

        [DataMember]
        public IAmLightstoneBusinessCompanyRequest Request { get; private set; }
    }
}