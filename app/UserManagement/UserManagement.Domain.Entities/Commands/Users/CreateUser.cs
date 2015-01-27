using System;
using System.Collections.Generic;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.Users
{
    public class CreateUser : DomainCommand
    {

        public DateTime FirstCreateDate;
        public string LastUpdateBy;
        public DateTime LastUpdateDate;
        public string Password;
        public string UserName;
        public bool? IsActive;
        public IList<Client> ClientObject;

        public UserType UserType;
        public IEnumerable<Customer> Customers;
        public IList<Role> Roles;

        //Profile data
        public string ContactNumber;
        public string FirstName;
        public string Surname;
        public string IdNumber;

        public CreateUser(DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, bool? isActive, UserType userType,
                            IEnumerable<Customer> customers,
                            IList<Client> client,
                            IList<Role> roles,
                            string contactNumber, string firstName, string surname, string idNumber)
        {
            Id = Guid.NewGuid();
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            IsActive = isActive;
            UserType = userType;
            Customers = customers;
            ClientObject = client;
            Roles = roles;

            //Profile
            ContactNumber = contactNumber;
            FirstName = firstName;
            Surname = surname;
            IdNumber = idNumber;

        }
    }
}