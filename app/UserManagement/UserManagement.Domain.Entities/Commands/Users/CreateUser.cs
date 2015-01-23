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
        public IEnumerable<ClientUser> ClientUser;

        public UserType UserType;
        public IEnumerable<UserLinkedToCustomer> UserLinkedToCustomer;
        public IEnumerable<UserProfile> UserProfile;
        public IList<Role> Roles;

        //Profile data
        public string ContactNumber;
        public string FirstName;
        public string Surname;
        public string IdNumber;

        public CreateUser(DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, bool? isActive,
                            //IEnumerable<ClientUser> clientUser, 
                            UserType userType,
                            //IEnumerable<UserLinkedToCustomer> userLinkedToCustomer, IEnumerable<UserProfile> userProfile, 
                            IList<Role> roles, 
                            string firstName, string surname, string idNumber, string contactNumber)
        {
            Id = Guid.NewGuid();
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            IsActive = isActive;
            //ClientUser = clientUser;
            UserType = userType;
            //UserLinkedToCustomer = userLinkedToCustomer;
            //UserProfile = userProfile;
            Roles = roles;

            //Profile
            ContactNumber = contactNumber;
            FirstName = firstName;
            Surname = surname;
            IdNumber = idNumber;

        }
    }
}