using Nancy;
using Nancy.Authentication.Token;
using Nancy.Security;
using Shared.BuildingBlocks.Api.ApiClients;

namespace PackageBuilder.TestHelper.Fakes
{
    public class FakeTokenizer : ITokenizer
    {
        public string Tokenize(IUserIdentity userIdentity, NancyContext context)
        {
            return "";
        }

        public IUserIdentity Detokenize(string token, NancyContext context, IUserIdentityResolver userIdentityResolver)
        {
            return new UserIdentity("FakeUser");
        }
    }
}