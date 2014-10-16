﻿using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.Data.Core.Security.Events;

namespace LightstoneApp.Infrastructure.Data.Core.Security
{
    public class User : Aggregate
    {
        private User()
        {
        }

        internal String Username { get; private set; }
        internal String FullName { get; private set; }

        private User SetupCompleted()
        {
            RaiseEvent(new UserCreated(Id, Username, FullName));

            return this;
        }

        public class Factory
        {
            public User CreatePerson(string firstName, string lastName)
            {
                var person = new User
                {
                    //Id = "users/" + Guid.NewGuid().ToString(),
                    FullName = firstName + " " + lastName,
                    Username = lastName + firstName
                };

                return person.SetupCompleted();
            }
        }
    }
}