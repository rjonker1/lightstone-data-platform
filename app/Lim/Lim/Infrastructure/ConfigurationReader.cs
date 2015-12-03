namespace Lim.Infrastructure
{
    public static class ConfigurationReader
    {
        static ConfigurationReader()
        {
            Bmw = new BmwConfiguration();
            Lim = new LimConfiguration();
            LsAuto = new LsAutoConfiguration();
            LimEventStore = new LimEventStoreConfiguration();
        }

        public static readonly BmwConfiguration Bmw;
        public static readonly LimConfiguration Lim;
        public static readonly LsAutoConfiguration LsAuto;
        public static readonly LimEventStoreConfiguration LimEventStore;
    }
}
