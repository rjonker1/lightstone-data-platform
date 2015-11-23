namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class TabletDeterminiator : AbstractDeterminator
    {
        public TabletDeterminiator()
            : base(Core.Enums.UserAgent.Tablet)
        {

        }

        public TabletDeterminiator(IDetermineUserAgent next)
            : base(next, Core.Enums.UserAgent.Tablet)
        {

        }
    }
}