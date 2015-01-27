using System;
using System.Collections.Generic;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class UserDto
    {

        //User
        public DateTime FirstCreateDate { get; set; }
        public string LastUpdateBy { get; set; }
        public DateTime LastUpdateDate { get; set; }
        public string Password { get; set; }
        public string UserName { get; set; }
        public bool? IsActive { get; set; }
        public UserType UserType { get; set; }
        public IEnumerable<Customer> Customers { get; set; }
        //public IEnumerable<Client> Clients { get; set; }
        //private List<ClientUser> ClientUsers { get; set; }

        //public IList<Client> Clients { get; set; } 
        public IList<Role> Roles { get; set; } 

        //Profile data
        public virtual string FirstName { get; set; }
        public virtual string Surname { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string ContactNumber { get; set; }

        public UserDto(DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, bool? isActive, UserType userType,
                        IEnumerable<Customer> customers, IList<Role> roles, string firstName, string surname, string idNumber, string contactNumber)
        {
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            IsActive = isActive;
            UserType = userType;
            Customers = customers;
            //Clients = clients;
            Roles = roles;
            FirstName = firstName;
            Surname = surname;
            IdNumber = idNumber;
            ContactNumber = contactNumber;
        }
    }
}