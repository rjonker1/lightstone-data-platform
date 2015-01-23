using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.UserProfiles
{
    public class CreateUserProfile : DomainCommand
    {

        public virtual string ContactNumber { get; set; }
        public virtual string FirstName { get; set; }
        public virtual string IdNumber { get; set; }
        public virtual string Surname { get; set; }

        public CreateUserProfile(string contactNumber, string firstName, string idNumber, string surname)
        {
            ContactNumber = contactNumber;
            FirstName = firstName;
            IdNumber = idNumber;
            Surname = surname;
        }

    }
}