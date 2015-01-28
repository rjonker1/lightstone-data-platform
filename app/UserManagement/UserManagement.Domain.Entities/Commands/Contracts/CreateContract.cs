using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Contracts
{
    public class CreateContract : DomainCommand
    {

        public DateTime ContractCommencementDate;
        public Guid ContractDurationId;
        public string ContractName;
        public Guid ContractTypeId;
        public Guid EscalationTypeId;
        public string LastUpdateBy;
        public DateTime LastUpdateDate;
        public Guid? ClientId;
        public string ContactDetail;
        public string EnteredIntoBy;
        public DateTime? OnlineAcceptance;
        public Guid? ProfileDetailId;
        public string RegisteredName;
        public string RegistrationNumber;

        public Client Client;
        //public ProfileDetail ProfileDetail;
        public ContractType ContractType;
        public EscalationType EscalationType;
        public ContractDuration ContractDuration;

        public CreateContract(DateTime contractCommencementDate, Guid contractDurationId, string contractName, Guid contractTypeId, Guid escalationTypeId, string lastUpdateBy, 
                                DateTime lastUpdateDate, Guid? clientId, string contactDetail, string enteredIntoBy, DateTime? onlineAcceptance, Guid? profileDetailId, 
                                string registeredName, string registrationNumber, Client client, ContractType contractType, EscalationType escalationType, ContractDuration contractDuration)

        {
            Id = Guid.NewGuid();
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
            ContractType = contractType;
            EscalationType = escalationType;
            ContractDuration = contractDuration;
        }
    }
}