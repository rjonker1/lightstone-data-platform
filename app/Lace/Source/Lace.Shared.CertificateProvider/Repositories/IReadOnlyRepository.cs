namespace Lace.Shared.CertificateProvider.Repositories
{
    public interface IReadOnlyRepository<T>
    {
        T Find(double latitude, double longitude);
        T[] GetAll();
    }
}
