using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class PCubedEzScoreResponse : IProvideDataFromPCubedEzScore
    {
        public PCubedEzScoreResponse()
        {
            ResponseState = DataProviderResponseState.NoRecords;
            EzScoreRecords = Enumerable.Empty<IRespondWithEzScore>();
        }

        public PCubedEzScoreResponse(IEnumerable<IRespondWithEzScore> ezScoreRecords)
        {
            EzScoreRecords = ezScoreRecords;
        }

        public static PCubedEzScoreResponse Empty()
        {
            return new PCubedEzScoreResponse();
        }

        public static PCubedEzScoreResponse WithRecords(IEnumerable<IRespondWithEzScore> ezScoreRecords)
        {
            return new PCubedEzScoreResponse(ezScoreRecords.ToList());
        }

        private PCubedEzScoreResponse(DataProviderResponseState state)
        {
            ResponseState = state;
            EzScoreRecords = Enumerable.Empty<IRespondWithEzScore>();
        }

        public static PCubedEzScoreResponse WithState(DataProviderResponseState state)
        {
            return new PCubedEzScoreResponse(state);
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
        public IAmPCubedEzScoreRequest Request { get; private set; }

        [DataMember]
        public IEnumerable<IRespondWithEzScore> EzScoreRecords { get; private set; }

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