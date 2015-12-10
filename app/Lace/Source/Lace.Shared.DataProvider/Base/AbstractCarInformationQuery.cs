using System.Collections.Generic;
using System.Linq;
using Lace.Domain.DataProviders.Core.Configuration;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Toolbox.Database.Base
{
    public abstract class AbstractCarInformationQuery
    {
        private readonly IGetCarInformation _next;
        public static readonly bool CacheAvailable = AutoCarstatsConfiguration.IsCached;

        protected AbstractCarInformationQuery()
        {
            
        }

        protected AbstractCarInformationQuery(IGetCarInformation next)
        {
            _next = next;
        }

        public bool Break(List<CarInformationDto> cars)
        {
            return cars != null && cars.Any() && cars.FirstOrDefault(f => f.CarId > 0 && f.Year > 0) != null;
        }

        protected List<CarInformationDto> CallNext(IHaveCarInformation request)
        {
            if(_next == null) return null;

            _next.GetCarInformation(request);
            return _next.Cars;
        }
    }
}