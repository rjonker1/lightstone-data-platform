using System;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class ContractDto
    {

        public DateTime ContractCommencementDate { get; set; }
        public Guid ContractDurationId { get; set; }
        public string ContractName { get; set; }
        public Guid ContractTypeId { get; set; }
        public Guid EscalationTypeId { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public Guid? ClientId { get; set; }
        public string ContactDetail { get; set; }
        public string EnteredIntoBy { get; set; }
        public DateTime? OnlineAcceptance { get; set; }
        public Guid? ProfileDetailId { get; set; }
        public string RegisteredName { get; set; }
        public string RegistrationNumber { get; set; }

        public Client Client { get; set; }
        //public ProfileDetail ProfileDetail { get; set; }
        public ContractType ContractType { get; set; }
        public EscalationType EscalationType { get; set; }
        public ContractDuration ContractDuration { get; set; }

        public ContractDto(DateTime contractCommencementDate, Guid contractDurationId, string contractName, Guid contractTypeId, Guid escalationTypeId, string lastUpdateBy, DateTime lastUpdateDate, Guid? clientId, string contactDetail, string enteredIntoBy, DateTime? onlineAcceptance, Guid? profileDetailId, string registeredName, string registrationNumber, Client client, /*ProfileDetail profileDetail,*/ ContractType contractType, EscalationType escalationType, ContractDuration contractDuration)
        {
            ContractCommencementDate = contractCommencementDate;
            ContractDurationId = contractDurationId;
            ContractName = contractName;
            ContractTypeId = contractTypeId;
            EscalationTypeId = escalationTypeId;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            ClientId = clientId;
            ContactDetail = contactDetail;
            EnteredIntoBy = enteredIntoBy;
            OnlineAcceptance = onlineAcceptance;
            ProfileDetailId = profileDetailId;
            RegisteredName = registeredName;
            RegistrationNumber = registrationNumber;
            Client = client;
            //ProfileDetail = profileDetail;
            ContractType = contractType;
            EscalationType = escalationType;
            ContractDuration = contractDuration;
        }
    }
}