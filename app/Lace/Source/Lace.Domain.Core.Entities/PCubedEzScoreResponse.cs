using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using PackageBuilder.Domain.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class PCubedEzScoreResponse : IProvideDataFromPCubedEzScore
    {
        public PCubedEzScoreResponse()
        {
            EzScoreRecords = Enumerable.Empty<IRespondWithEzScore>();
        }

        private PCubedEzScoreResponse(string message)
        {
            EzScoreRecords = Enumerable.Empty<IRespondWithEzScore>();
            HasCriticalFailure = true;
            CriticalFailureMessage = message;
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

        public static PCubedEzScoreResponse Failure(string message)
        {
            return new PCubedEzScoreResponse(message);
        }

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


        [DataMember]
        public bool HasCriticalFailure { get; private set; }

        [DataMember]
        public string CriticalFailureMessage { get; private set; }

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