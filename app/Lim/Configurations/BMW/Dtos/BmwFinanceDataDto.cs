using System.Runtime.Serialization;

namespace Toolbox.Bmw.Dtos
{
    [DataContract]
    public class BmwFinanceDataDto
    {
        public BmwFinanceDataDto()
        {

        }

        public BmwFinanceDataDto(string chassis, string engine, string registrationNumber, string description, int registrationYear,
            string dealType, string dealStatus)
        {
            Chassis = chassis;
            Engine = engine;
            RegistrationNumber = registrationNumber;
            Description = description;
            RegistrationYear = registrationYear;
            DealStatus = dealStatus;
        }

        [DataMember]
        public string Chassis { get; private set; }

        [DataMember]
        public string Engine { get; private set; }

        [DataMember]
        public string RegistrationNumber { get; private set; }

        [DataMember]
        public string Description { get; private set; }

        [DataMember]
        public int RegistrationYear { get; private set; }

        [DataMember]
        public string DealType { get; private set; }

        [DataMember]
        public string DealStatus { get; private set; }
    }
}
