using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Vin12;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class Vin12Response : IProvideDataFromVin12
    {
        public Vin12Response()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            Vin12Information = Enumerable.Empty<IRespondWithVin12>();
        }

        public static Vin12Response Empty()
        {
            return new Vin12Response();
        }

        public Vin12Response(IEnumerable<IRespondWithVin12> vin12Information)
        {
            Vin12Information = vin12Information;
        }

        private Vin12Response(DataProviderResponseState state)
        {
            ResponseState = state;
            Vin12Information = Enumerable.Empty<IRespondWithVin12>();
        }

        public static Vin12Response WithState(DataProviderResponseState state)
        {
            return new Vin12Response(state);
        }

        public void AddResponseState(DataProviderResponseState state)
        {
            ResponseState = state;
        }

        public void HasNotBeenHandled()
        {
            Handled = false;
        }

        public void HasBeenHandled()
        {
            Handled = true;
        }

        [DataMember]
        public IAmVin12Request Request { get; private set; }

        [DataMember]
        public IEnumerable<IRespondWithVin12> Vin12Information { get; private set; }

        [DataMember]
        public bool Handled { get; private set; }

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
        public DataProviderResponseState ResponseState { get; private set; }

        [DataMember]
        public string ResponseStateMessage
        {
            get { return ResponseState.Description(); }
        }

        
    }
}