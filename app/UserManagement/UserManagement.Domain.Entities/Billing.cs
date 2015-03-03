using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {
        [Required]
        public virtual string ContactNumber { get; set; }
        [Required]
        public virtual string ContractPerson { get; set; }
        [Required, DomainSignature]
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }
        public virtual string PastelId { get; set; }
        public virtual string VatNumber { get; set; }
        [Required]
        public virtual PaymentType PaymentType { get; set; }

        protected internal Billing() { }

        public Billing(string contactNumber, string contractPerson, string companyRegistration, DateTime? debitOrderDate, string pastelId, string vatNumber, PaymentType paymentType, Guid id = new Guid()) : base(id)
        {
            ContactNumber = contactNumber;
            ContractPerson = contractPerson;
            CompanyRegistration = companyRegistration;
            DebitOrderDate = debitOrderDate;
            PastelId = pastelId;
            VatNumber = vatNumber;
            PaymentType = paymentType;
        }
    }
}
