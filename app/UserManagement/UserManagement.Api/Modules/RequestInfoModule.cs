using AutoMapper;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class RequestInfoModule : SecureModule
    {
        public RequestInfoModule(IUserRepository userRepository)
        {
            Get["/RequestInfo/"] = _ =>
            {
                var user = userRepository.Get(Context.CurrentUser.UserName);
                return user == null ? null : Mapper.Map<User, RequestInfoDto>(user);
            };
        }
    }
}