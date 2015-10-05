using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany
{
    public class LightstoneConsumerBuilder
    {
        int _date;
        string _cost;
        string _driversName;
        string _location;
        string _vehicleDescription;

        public IRespondWithRepairData Build()
        {
            return new RepairDataResponse(_vehicleDescription, _cost, _date, _driversName, _location);
        }

        public LightstoneConsumerBuilder With(int date)
        {
            _date = date;
            return this;
        }

        public LightstoneConsumerBuilder With(string cost, string driversName, string location, string vehicleDescription)
        {
            _vehicleDescription = vehicleDescription;
            _cost = cost;
            _driversName = driversName;
            _location = location;

            return this;
        }
    }
}