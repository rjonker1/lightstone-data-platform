using DataProvider.Domain.Models.RequestFields;

namespace DataProvider.Infrastructure.Factory
{
    public interface IFindRequestFieldFactory
    {
        IFindRequestField Create();
    }

    public class RequestFieldFinderFactory : IFindRequestFieldFactory
    {
        public IFindRequestField Create()
        {
            return new VinNumberFinder(new CarIdFinder(new LicenseNumberFinder(new RegistrationNumberFinder(new IdNumberFinder(new ScanDataFinder(new UndefinedFinder()))))));
        }
    }
}