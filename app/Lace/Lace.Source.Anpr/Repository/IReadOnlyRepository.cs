namespace Lace.Source.Anpr.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T Find(double latitude, double longitude);
        T[] GetAll();
    }
}
