using Lace.Domain.Core.Contracts.Requests;

namespace PackageBuilder.Domain.Entities.DataProviders.Commands
{
    public class CreateLightstoneDataProvider 
    {
        public IPointToLaceProvider DataProvider { get; set; }

        public CreateLightstoneDataProvider(IPointToLaceProvider dataProvider)
        {
            DataProvider = dataProvider;
        }
    }
}