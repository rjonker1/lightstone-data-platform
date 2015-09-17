namespace Lim.Core
{
    public interface IPullConfiguration
    {
        void Pull(object command);
    }

    public interface IPullConfiguration<in T> : IPullConfiguration
    {
        void Pull(T command);
    }
}
