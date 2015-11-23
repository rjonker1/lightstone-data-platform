namespace Monitoring.Dashboard.UI.Domain.UserAgent
{
    public sealed class PhoneDeterminator : AbstractDeterminator
    {
        public PhoneDeterminator()
            : base(Core.Enums.UserAgent.Phone)
        {
            
        }

        public PhoneDeterminator(IDetermineUserAgent next) : base(next, Core.Enums.UserAgent.Phone)
        {
            
        }
    }
}