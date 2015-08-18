using System;
using System.Collections.Generic;
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
            
        }

        public PCubedEzScoreResponse(IEnumerable<IRespondWithEzScore> ezScoreRecords)
        {
            EzScoreRecords = ezScoreRecords;
        }

        public static PCubedEzScoreResponse Empty()
        {
            return new PCubedEzScoreResponse(new List<IRespondWithEzScore>());
        }

        public static PCubedEzScoreResponse WithRecords(IEnumerable<IRespondWithEzScore> ezScoreRecords)
        {
            return new PCubedEzScoreResponse(ezScoreRecords);
        }


        [DataMember]
        public IAmPCubedEzScoreRequest Request { get; private set; }
        [DataMember]
        public IEnumerable<IRespondWithEzScore> EzScoreRecords { get; private set; }

        [DataMember]
        public string TypeName
        {
            get
            {
                return GetType().Name;
            }
        }

        [DataMember]
        public Type Type
        {
            get
            {
                return GetType();
            }
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