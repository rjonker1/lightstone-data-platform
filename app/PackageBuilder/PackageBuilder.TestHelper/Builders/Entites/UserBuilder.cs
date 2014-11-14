using System.Linq;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class UserBuilder
    {
        private string _username;
        private IGroup[] _groups = Enumerable.Empty<IGroup>().ToArray();
        private IRole[] _roles = Enumerable.Empty<IRole>().ToArray();

        public IUser Build()
        {
            var user = new User(_username);

            foreach (var @group in _groups)
                user.Add(@group);

            foreach (var role in _roles)
                user.Add(role);

            return user;
        }

        public UserBuilder With(string username)
        {
            _username = username;
            return this;
        }

        public UserBuilder With(params IGroup[] groups)
        {
            _groups = groups;
            return this;
        }

        public UserBuilder With(params IRole[] roles)
        {
            _roles = roles;
            return this;
        }
    }
}