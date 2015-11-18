namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class ApiDeterminiator : AbstractDeterminator
    {
        public ApiDeterminiator()
            : base(Core.Enums.UserAgent.Api)
        {

        }

        public ApiDeterminiator(IDetermineUserAgent next)
            : base(next, Core.Enums.UserAgent.Api)
        {

        }
    }
}