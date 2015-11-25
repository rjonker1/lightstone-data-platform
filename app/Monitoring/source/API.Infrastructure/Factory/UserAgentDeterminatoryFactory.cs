using Api.Infrastructure.UserAgent;

namespace Api.Infrastructure.Factory
{
    public interface IDetermineUserAgentFactory
    {
        IDetermineUserAgent Create();
    }

    public class UserAgentDeterminatoryFactory : IDetermineUserAgentFactory
    {
        public IDetermineUserAgent Create()
        {
            return new PhoneDeterminator(new TabletDeterminiator(new ApiDeterminiator(new BrowserDeterminator(new UndefinedDeterminator()))));
        }
    }
}