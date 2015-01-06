namespace Lace.CrossCutting.DataProviderCommandSource.Certificate.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        T Find(double latitude, double longitude);
        T[] GetAll();
    }
}
