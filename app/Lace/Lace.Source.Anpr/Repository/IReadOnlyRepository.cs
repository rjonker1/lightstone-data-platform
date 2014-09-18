namespace Lace.Source.Anpr.Repository
{
    public interface IReadOnlyRepository<T>
    {
        T FindFirstWith(double latitude, double longitude);
    }
}
