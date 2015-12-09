using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.DataProviders.Core.Factories;
using Lace.Shared.Extensions;
using Lace.Toolbox.Database.Base;
using PackageBuilder.Domain.Requests.Contracts.RequestFields;

namespace Lace.Toolbox.Database.Requests.CarInformation
{
    public abstract class AbstractRequestDeterminator
    {
        private readonly IDetermineRequestType _next;
        private readonly IMineDataProviderResponseFactory _factory;
        private readonly ICollection<IPointToLaceProvider> _response;

        protected AbstractRequestDeterminator(IDetermineRequestType next)
        {
            _next = next;
        }

        protected AbstractRequestDeterminator(ICollection<IPointToLaceProvider> response, IDetermineRequestType next, IMineDataProviderResponseFactory factory)
            : this(next)
        {
            _response = response;
            _factory = factory;
        }

        public IRetrieveCarInformation SearchNext()
        {
            return _next.Retrieve();
        }

        protected int GetCarId(IAmCarIdRequestField carid)
        {
            if (carid == null)
                return _factory.BuildCarIdMiners(_response).MineCarId();

            int carId;
            int.TryParse(carid.GetValue(), out carId);

            if (carId == 0)
                carId = _factory.BuildCarIdMiners(_response).MineCarId();

            return carId;
        }

        protected int GetYear(IAmYearRequestField year)
        {
            if (year == null)
                return 0;

            int yearId;
            int.TryParse(year.GetValue(), out yearId);
            return yearId;
        }

        protected string GetVinNumber(IAmVinNumberRequestField vinNumber)
        {
            if(vinNumber == null)
                return _factory.BuildVinMiners(_response).MineVin();

            //always take vin number from response over request
            var responseVin = _factory.BuildVinMiners(_response).MineVin();
            var requestVin = vinNumber.GetValue();

            if (string.IsNullOrEmpty(responseVin))
                return requestVin;

            return !string.IsNullOrEmpty(requestVin) && requestVin.Equals(responseVin, StringComparison.CurrentCultureIgnoreCase) ? requestVin : responseVin;
           // return !string.IsNullOrEmpty(vinNumber.GetValue()) && responseVin == vinNumber.g ? vinNumber.GetValue() : _factory.BuildVinMiners(_response).MineVin();
        }
    }
}
