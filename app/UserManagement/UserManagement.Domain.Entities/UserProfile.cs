﻿using System;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Entities
{
    public class UserProfile : Entity
    {
        public virtual string ContactNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string Surname { get; set; }

        public virtual User User { get; set; }

        protected UserProfile()
        {
            
        }

        public UserProfile(string contactNumber, string firstName, string idNumber, string surname, User user)
        {
            Id = Guid.NewGuid();
            ContactNumber = contactNumber;
            FirstName = firstName;
            IdNumber = idNumber;
            Surname = surname;

            User = user;
        }
    }
}