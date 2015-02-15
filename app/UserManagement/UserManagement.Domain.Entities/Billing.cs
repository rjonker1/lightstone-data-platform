using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string ContactNumber { get; set; }
        public virtual string ContractPerson { get; set; }
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }
        public virtual string PastelId { get; set; }
        public virtual string VatNumber { get; set; }
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
