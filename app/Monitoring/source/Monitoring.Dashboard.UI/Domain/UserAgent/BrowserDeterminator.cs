namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class BrowserDeterminator : AbstractDeterminator
    {
        public BrowserDeterminator()
            : base(Core.Enums.UserAgent.Browser)
        {

        }

        public BrowserDeterminator(IDetermineUserAgent next)
            : base(next, Core.Enums.UserAgent.Browser)
        {

        }
    }
}