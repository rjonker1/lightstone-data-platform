namespace Lim.Infrastructure
{
    public static class Configurations
    {
        static Configurations()
        {
            Bmw = new BmwConfiguration();
            Lim = new LimConfiguration();
        }

        public static readonly BmwConfiguration Bmw;
        public static readonly LimConfiguration Lim;
    }
}
