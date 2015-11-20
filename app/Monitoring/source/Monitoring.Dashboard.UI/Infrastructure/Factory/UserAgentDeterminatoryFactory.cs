using Monitoring.Dashboard.UI.Domain.UserAgent;

namespace Monitoring.Dashboard.UI.Infrastructure.Factory
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