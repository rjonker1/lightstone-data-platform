using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;

namespace Shared.BuildingBlocks.Api.Security
{
    public interface IDataPlatformTokenizer : ITokenizer
    {
        IUserIdentity Detokenize(string token, NancyContext context, IUserIdentityResolver userIdentityResolver, SystemName systemName);
    }
}