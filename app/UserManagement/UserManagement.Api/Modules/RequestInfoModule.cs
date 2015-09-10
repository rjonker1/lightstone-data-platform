using AutoMapper;
using DataPlatform.Shared.Dtos.RequestInfo;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class RequestInfoModule : SecureModule
    {
        public RequestInfoModule(IUserRepository userRepository)
        {
            Get["/RequestInfo/{username}"] = _ =>
            {
                //var user = userRepository.Get(Context.CurrentUser.UserName);
                var user = userRepository.GetByUserName(_.username);
                return user == null ? null : Mapper.Map<User, RequestInfoDto>(user);
            };
        }
    }
}