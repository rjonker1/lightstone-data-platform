using System;
using System.Runtime.Serialization;

namespace DataProviders.Xds.IdentityVerification.Infrastructure.Dto
{
    [Serializable]
    [DataContract]
    public class ConsumerDetails
    {
        [DataMember]
        public int ConsumerID { get; set; }

        [DataMember]
        public string HomeAffairsID { get; set; }

        [DataMember]
        public long Idno { get; set; }

        [DataMember]
        public string FirstName { get; set; }

        [DataMember]
        public string SecondName { get; set; }

        [DataMember]
        public string Surname { get; set; }

        [DataMember]
        public string DeceasedStatus { get; set; }

        [DataMember]
        public string IDIssuedDate { get; set; }

        [DataMember]
        public string CauseOfDeath { get; set; }

        [DataMember]
        public string BonusXML { get; set; }

        [DataMember]
        public string TempReference { get; set; }

        [DataMember]
        public long EnquiryID { get; set; }

        [DataMember]
        public long EnquiryResultID { get; set; }

        [DataMember]
        public string Reference { get; set; }

        //  <ConsumerID>0</ConsumerID>
        //<HomeAffairsID>61180391</HomeAffairsID>
        //<Idno>8310245010082</Idno>
        //<FirstName>RUDI</FirstName>
        //<SecondName />
        //<Surname>JONKER</Surname>
        //<DeceasedStatus>Active</DeceasedStatus>
        //<IDIssuedDate>2000-03-02T00:00:00+02:00</IDIssuedDate>
        //<CauseOfDeath />
        //<BonusXML />
        //<TempReference />
        //<EnquiryID>51153702</EnquiryID>
        //<EnquiryResultID>51477899</EnquiryResultID><
        //Reference>H51153702-61180391</Reference>
    }
}
