namespace Api.Infrastructure.UserAgent
{
    public sealed class BrowserDeterminator : AbstractDeterminator
    {
        public BrowserDeterminator()
            : base(Enums.UserAgent.Browser)
        {

        }

        public BrowserDeterminator(IDetermineUserAgent next)
            : base(next, Enums.UserAgent.Browser)
        {

        }
    }
}