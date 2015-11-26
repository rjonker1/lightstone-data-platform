namespace Api.Infrastructure.UserAgent
{
    public sealed class PhoneDeterminator : AbstractDeterminator
    {
        public PhoneDeterminator()
            : base(Enums.UserAgent.Phone)
        {
            
        }

        public PhoneDeterminator(IDetermineUserAgent next) : base(next, Enums.UserAgent.Phone)
        {
            
        }
    }
}