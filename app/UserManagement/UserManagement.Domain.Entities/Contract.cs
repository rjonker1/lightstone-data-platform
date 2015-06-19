using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class Contract : NamedEntity
    {
        public virtual DateTime CommencementDate { get; set; }
        public virtual string Description { get; set; }
        public virtual string EnteredIntoBy { get; set; }
        public virtual DateTime? OnlineAcceptance { get; set; }
        public virtual string RegisteredName { get; set; }
        public virtual string RegistrationNumber { get; set; }
        public virtual ContractType ContractType { get; set; }
        public virtual EscalationType EscalationType { get; set; }
        public virtual ContractDuration ContractDuration { get; set; }
        public virtual ISet<Client> Clients { get; set; }
        public virtual ISet<Customer> Customers { get; set; }
        [DoNotMap]
        public virtual bool HasPackage {
            get
            {
                return Packages.Any();
            } 
        }
        public virtual bool HasPackagePriceOverride { get; set; }
        public virtual ContractBundle ContractBundle { get; set; }

        public virtual bool IsActive { get; set; }
        //public virtual ISet<ContractPackage> ContractPackages { get; set; }
        //public virtual IEnumerable<Guid> ContractPackageIds
        //{
        //    get
        //    {
        //        return ContractPackages != null
        //            ? ContractPackages.Select(x => x.Id)
        //            : Enumerable.Empty<Guid>();
        //    }
        //}
        public virtual ISet<Package> Packages { get; set; }

        protected Contract() { }

        public Contract(DateTime commencementDate, string name, string description, string enteredIntoBy, DateTime? onlineAcceptance, string registeredName, string registrationNumber, ContractType contractType, EscalationType escalationType, ContractDuration contractDuration, Guid id = new Guid()) 
            : base(name)
        {
            CommencementDate = commencementDate;
            Name = name;
            Description = description;
            EnteredIntoBy = enteredIntoBy;
            OnlineAcceptance = onlineAcceptance;
            RegisteredName = registeredName;
            RegistrationNumber = registrationNumber;
            ContractType = contractType;
            EscalationType = escalationType;
            ContractDuration = contractDuration;
        }
    }
}
