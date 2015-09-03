using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetStatistics
    {
        IEnumerable<Statistic> Statistics { get; }
        void GetStatistics(IHaveCarInformation request);
    }
}
