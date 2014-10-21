﻿using System;
using DataPlatform.Shared.Entities;

namespace PackageBuilder.Domain.Entities
{
    public class UserPackage : IUserPackage
    {
        public UserPackage(Guid id, IPackage package, ICustomer customer, IUser user, DateTime validUntil)
        {
            Id = id;
            Package = package;
            Customer = customer;
            User = user;
            ValidUntil = validUntil;
        }

        public Guid Id { get; private set; }
        public IPackage Package { get; set; }
        public ICustomer Customer { get; set; }
        public IUser User { get; set; }
        public DateTime ValidUntil { get; set; }
    }
}