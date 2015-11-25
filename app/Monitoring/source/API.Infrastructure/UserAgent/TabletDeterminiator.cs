namespace Api.Infrastructure.UserAgent
{
    public sealed class TabletDeterminiator : AbstractDeterminator
    {
        public TabletDeterminiator()
            : base(Enums.UserAgent.Tablet)
        {

        }

        public TabletDeterminiator(IDetermineUserAgent next)
            : base(next, Enums.UserAgent.Tablet)
        {

        }
    }
}