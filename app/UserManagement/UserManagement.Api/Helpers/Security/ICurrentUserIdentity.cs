using Nancy.Security;

namespace UserManagement.Api.Helpers.Security
{
    public interface ICurrentUserIdentity
    {
        IUserIdentity UserIdentity { get; set; }
    }

    public class CurrentUserIdentity : ICurrentUserIdentity
    {
        public IUserIdentity UserIdentity { get; set; }
    }
}