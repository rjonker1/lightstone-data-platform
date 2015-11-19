using System;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Billing : Entity
    {
        public virtual string LegalEntityName { get; protected internal set; }
        public virtual string AccountContactName { get; protected internal set; }
        public virtual string AccountContactNumber { get; protected internal set; }
        public virtual string AccountContactEmail { get; protected internal set; }
        public virtual string CompanyRegistration { get; protected internal set; }
        public virtual DateTime? DebitOrderDate { get; protected internal set; }
        public virtual string DebitOrderAccountOwner { get; protected internal set; }
        public virtual string DebitOrderAccountNumber { get; protected internal set; }
        public virtual string DebitOrderBranchCode { get; protected internal set; }
        public virtual string PastelId { get; protected internal set; }
        public virtual string VatNumber { get; protected internal set; }
        public virtual PaymentType PaymentType { get; protected internal set; }

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
