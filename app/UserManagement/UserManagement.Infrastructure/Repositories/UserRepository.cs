using System;
using System.Linq;
using DataPlatform.Shared.Helpers;
using NHibernate;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Helpers;

namespace UserManagement.Infrastructure.Repositories
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByUserName(string username);
        User GetByResetToken(Guid resetToken);
        PagedList<User> Search(string searchValue, int pageIndex, int pageSize);
    }

    public class UserRepository : Repository<User>, IUserRepository
    {
        public UserRepository(ISession session)
            : base(session)
        {
        }

        public User GetByUserName(string username)
        {
            return this.FirstOrDefault(x => (x.UserName + "").Trim().ToLower() == (username + "").Trim().ToLower());
        }

        public User GetByResetToken(Guid resetToken)
        {
            return this.FirstOrDefault(x => x.ResetPasswordToken  == resetToken);
        }

        public PagedList<User> Search(string searchValue, int pageIndex, int pageSize)
        {
            var predicate = PredicateBuilder.False<User>();
            predicate = predicate.Or(x => (x.FirstName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            predicate = predicate.Or(x => (x.LastName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            predicate = predicate.Or(x => (x.UserName + "").Trim().ToLower().StartsWith((searchValue + "").Trim().ToLower()));
            return new PagedList<User>(this, pageIndex, pageSize, predicate);
        }
    }
}