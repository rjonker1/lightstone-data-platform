namespace Lim.Infrastructure
{
    public static class ConfigurationReader
    {
        static ConfigurationReader()
        {
            Bmw = new BmwConfiguration();
            Lim = new LimConfiguration();
        }

        public static readonly BmwConfiguration Bmw;
        public static readonly LimConfiguration Lim;
    }
}
