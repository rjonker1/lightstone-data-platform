using System;
using UserManagement.Domain.Core.Commands;
using UserManagement.Domain.Core.MessageHandling;

namespace UserManagement.Domain.Entities.Commands.Users
{
    public class CreateUser : DomainCommand
    {

        public DateTime FirstCreateDate { get; private set; }
        public string LastUpdateBy { get; private set; }
        public DateTime LastUpdateDate { get; private set; }
        public string Password { get; private set; }
        public string UserName { get; private set; }
        public Guid UserTypeId { get; private set; }
        public bool? IsActive { get; private set; }

        private readonly IHandleMessages _handler;

        public CreateUser(DateTime firstCreateDate, string lastUpdateBy, DateTime lastUpdateDate, string password, string userName, Guid userTypeId, bool? isActive)
        {
            FirstCreateDate = firstCreateDate;
            LastUpdateBy = lastUpdateBy;
            LastUpdateDate = lastUpdateDate;
            Password = password;
            UserName = userName;
            UserTypeId = userTypeId;
            IsActive = isActive;
        }
    }
}