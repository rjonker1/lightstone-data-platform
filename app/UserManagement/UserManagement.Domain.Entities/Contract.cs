using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Contract : Entity
    {
        public virtual DateTime ContractCommencementDate { get; set; }
        public virtual string ContractName { get; set; }
        public virtual string ContactDetail { get; set; }
        public virtual string EnteredIntoBy { get; set; }
        public virtual DateTime? OnlineAcceptance { get; set; }
        public virtual string RegisteredName { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual Client Client { get; set; }
        //public virtual ProfileDetail ProfileDetail { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual EscalationType EscalationType { get; set; }
        public virtual ContractDuration ContractDuration { get; set; }
        public virtual List<Package> Packages { get; set; }

        protected Contract() { }

        public Contract(Guid id, DateTime contractCommencementDate, string contractName, string contactDetail, string enteredIntoBy, DateTime? onlineAcceptance, string registeredName, string registrationNumber, Client client, ContractType contractType, EscalationType escalationType, ContractDuration contractDuration) : base(id)
        {
            ContractCommencementDate = contractCommencementDate;
            ContractName = contractName;
            ContactDetail = contactDetail;
            EnteredIntoBy = enteredIntoBy;
            OnlineAcceptance = onlineAcceptance;
            RegisteredName = registeredName;
            RegistrationNumber = registrationNumber;
            Client = client;
            ContractType = contractType;
            EscalationType = escalationType;
            ContractDuration = contractDuration;
        }
    }
}
