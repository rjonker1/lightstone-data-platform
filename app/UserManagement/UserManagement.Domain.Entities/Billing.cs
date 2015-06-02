using System;
using System.ComponentModel.DataAnnotations;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string LegalEntityName { get; set; }
        public virtual string AccountContactName { get; set; }
        public virtual string AccountContactNumber { get; set; }
        public virtual string AccountContactEmail { get; set; }
        public virtual string CompanyRegistration { get; set; }
        public virtual DateTime? DebitOrderDate { get; set; }
        public virtual string DebitOrderAccountOwner { get; set; }
        public virtual string DebitOrderAccountNumber { get; set; }
        public virtual string PastelId { get; set; }
        public virtual string VatNumber { get; set; }
        public virtual PaymentType PaymentType { get; set; }

        protected internal Billing() { }

        public Billing(string legalEntityName, string accountContactName, string companyRegistration, DateTime? debitOrderDate, string pastelId, string vatNumber, PaymentType paymentType, Guid id = new Guid())
            : base(id)
        {
            LegalEntityName = legalEntityName;
            AccountContactName = accountContactName;
            CompanyRegistration = companyRegistration;
            DebitOrderDate = debitOrderDate;
            PastelId = pastelId;
            VatNumber = vatNumber;
            PaymentType = paymentType;
        }
    }
}
