namespace Api.Infrastructure.UserAgent
{
    public sealed class ApiDeterminiator : AbstractDeterminator
    {
        public ApiDeterminiator()
            : base(Enums.UserAgent.Api)
        {

        }

        public ApiDeterminiator(IDetermineUserAgent next)
            : base(next, Enums.UserAgent.Api)
        {

        }
    }
}