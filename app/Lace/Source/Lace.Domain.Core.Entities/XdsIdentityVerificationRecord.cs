using System;
using System.Runtime.Serialization;
using Lace.Domain.Core.Contracts.DataProviders.Xds;

namespace Lace.Domain.Core.Entities
{
    [DataContract]
    public class IdentityVerificationRecord : IRespondWithIdentityVerification
    {
        public IdentityVerificationRecord()
        {

        }

        public IdentityVerificationRecord(long idNumber, int consumerId, string homeAffairsId, string firstName, string secondName, string surname,
            string deceasedStatus, string issueDate, string causeOfDeath, long enquiryId, long enquiryResultId, string reference)
        {
            IdNumber = idNumber;
            ConsumerId = consumerId;
            HomeAffairsId = homeAffairsId;
            FirstName = firstName;
            SecondName = secondName;
            Surname = surname;
            DeceasedStatus = deceasedStatus;
            IdIssuedDate = issueDate;
            CauseOfDeath = causeOfDeath;
            EnquiryId = enquiryId;
            EnquiryResultId = enquiryResultId;
            Reference = reference;
        }


        [DataMember]
        public long IdNumber { get; private set; }

        [DataMember]
        public int ConsumerId { get; private set; }

        public string HomeAffairsId { get; private set; }

        [DataMember]
        public string FirstName { get; private set; }

        [DataMember]
        public string SecondName { get; private set; }

        [DataMember]
        public string Surname { get; private set; }

        [DataMember]
        public string DeceasedStatus { get; private set; }

        [DataMember]
        public string IdIssuedDate { get; private set; }

        [DataMember]
        public string CauseOfDeath { get; private set; }

        [DataMember]
        public long EnquiryId { get; private set; }

        [DataMember]
        public long EnquiryResultId { get; private set; }

        [DataMember]
        public string Reference { get; private set; }

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
    }
}