using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Contract : NamedEntity
    {
        public virtual DateTime CommencementDate { get; protected internal set; }
        public virtual string Description { get; protected internal set; }
        public virtual string EnteredIntoBy { get; protected internal set; }
        public virtual DateTime? OnlineAcceptance { get; protected internal set; }
        public virtual string RegisteredName { get; protected internal set; }
        public virtual string RegistrationNumber { get; protected internal set; }
        public virtual ContractType ContractType { get; protected internal set; }
        public virtual EscalationType EscalationType { get; protected internal set; }
        public virtual ContractDuration ContractDuration { get; protected internal set; }
        public virtual ISet<Client> Clients { get; protected internal set; }
        public virtual ISet<Customer> Customers { get; protected internal set; }
        [DoNotMap]
        public virtual bool HasPackage {
            get
            {
                return Packages.Any();
            } 
        }
        public virtual bool HasPackagePriceOverride { get; protected internal set; }
        //public virtual ContractBundle ContractBundle { get; protected internal set; }
        public virtual Guid? ContractBundleId { get; protected internal set; }

        public virtual bool IsActive { get; protected internal set; }
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
        public virtual ISet<Package> Packages { get; protected internal set; }

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

        public virtual void Activate(bool activate)
        {
            IsActive = activate;
        }
    }
}
