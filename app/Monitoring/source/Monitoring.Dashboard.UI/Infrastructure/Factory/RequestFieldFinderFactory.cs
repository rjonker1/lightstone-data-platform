using Monitoring.Dashboard.UI.Core.Models.DataProvider.RequestFields;

namespace Monitoring.Dashboard.UI.Infrastructure.Factory
{
    public interface IFindRequestFieldFactory
    {
        IFindRequestField Create();
    }

    public class RequestFieldFinderFactory : IFindRequestFieldFactory
    {
        public IFindRequestField Create()
        {
            return new VinNumberFinder(new CarIdFinder(new LicenseNumberFinder(new UndefinedFinder())));
        }
    }
}