namespace Lace.CrossCutting.DataProvider.Certificate.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        T Find(double latitude, double longitude);
        T[] GetAll();
    }
}
