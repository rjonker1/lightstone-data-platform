using System;
using System.Collections.Generic;
using System.Linq;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.NHibernate.Attributes;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Entities
{
    public class Individual : Entity, INamedEntity
    {
        [Unique]
        public virtual string Name { get; protected internal set; }
        [Unique]
        public virtual string Surname { get; protected internal set; }
        [Unique]
        public virtual string IdNumber { get; protected internal set; }
        public virtual ISet<IndividualAddress> Addresses { get; protected internal set; }
        public virtual ISet<IndividualEmail> Emails { get; protected internal set; }
        public virtual ISet<IndividualContactNumber> ContactNumbers { get; protected internal set; }
        [DoNotMap]
        public virtual string ContactNumber
        {
            get
            {
                if (ContactNumbers != null)
                {
                    var contactNumber = ContactNumbers.FirstOrDefault(x => x.ContactNumberType == ContactNumberType.Work);
                    return contactNumber != null ? contactNumber.ContactNumber : "";
                }
                return "";
            }
        }
        [DoNotMap]
        public virtual string Email
        {
            get
            {
                if (Emails != null)
                {
                    var email = Emails.FirstOrDefault();
                    return email != null ? email.Email : "";
                }
                return "";
            }
        }

        protected Individual() { }

        public Individual(string name, string surname, string idNumber, Guid id = new Guid()) : base(id)
        {
            Name = name;
            Surname = surname;
            IdNumber = idNumber;
        }

        public virtual void SetEmail(string email)
        {
            var individualEmail = Emails.FirstOrDefault(x => x.Individual.Id == Id && (x.Email + "").Trim().ToLower() == (email + "").Trim().ToLower());
            if (individualEmail == null)
            {
                individualEmail = new IndividualEmail(this, email);
                Emails.Add(individualEmail);
            }
            individualEmail.Email = email;
        }

        public virtual void SetContactNumber(string number, ContactNumberType type)
        {
            var individualContactNumber = ContactNumbers.FirstOrDefault(x => x.Individual.Id == Id && (x.ContactNumber + "").Trim().ToLower() == (number + "").Trim().ToLower());
            if (individualContactNumber == null)
            {
                individualContactNumber = new IndividualContactNumber(this, number, type);
                ContactNumbers.Add(individualContactNumber);
            }
            individualContactNumber.ContactNumber = number;
        }
    }
}