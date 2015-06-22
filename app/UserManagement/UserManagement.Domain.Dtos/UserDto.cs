using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace UserManagement.Domain.Dtos
{
    public class UserDto : EntityDto
    {
        public UserDto()
        {
            RoleIds = Enumerable.Empty<Guid>();
            RoleValues = Enumerable.Empty<string>();
            CustomerIds = Enumerable.Empty<Guid>();
            ClientIds = Enumerable.Empty<Guid>();
            Customers = Enumerable.Empty<NamedEntityDto>();
        }

        public virtual Guid Id { get; set; }
        [Required]
        [Display(Name = "Name is required")]
        public virtual string FirstName { get; set; }
        [Required]
        [Display(Name = "Surname is required")]
        public virtual string LastName { get; set; }
        [RegularExpression(@"(((\d{2}((0[13578]|1[02])(0[1-9]|[12]\d|3[01])|(0[13456789]|1[012])(0[1-9]|[12]\d|30)|02(0[1-9]|1\d|2[0-8])))|([02468][048]|[13579][26])0229))(( |-)(\d{4})( |-)(\d{3})|(\d{7}))", ErrorMessage = "Invalid ID Number")]
        public virtual string IdNumber { get; set; }
        [Required]
        [Display(Name = "Contact number is required")]
        [Phone(ErrorMessage = "Contact Number is not a valid phone number")]
        public virtual string ContactNumber { get; set; }
        [Required]
        [Display(Name = "Username is required")]
        [EmailAddress]
        public string UserName { get; set; }
        [Required]
        [Display(Name = "Password is required")]
        public string Password { get; set; }
        public string ActivationStatusType { get; set; }
        public bool? IsActive { get; set; }
        public bool IsLocked { get; set; }
        public DateTime? TrialExpiration { get; set; }
        public string UserType { get; set; }
        public IEnumerable<Guid> RoleIds { get; set; }
        public IEnumerable<string> RoleValues { get; set; }
        public IEnumerable<Guid> CustomerIds { get; set; }
        public IEnumerable<NamedEntityDto> Customers { get; set; }
        public IEnumerable<Guid> ClientIds { get; set; }
        public IEnumerable<string> Clients { get; set; }
        //public IEnumerable<ClientUserDto> ClientUsers { get; set; }
    }
}