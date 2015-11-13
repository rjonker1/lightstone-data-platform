using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetStatistics
    {
        IEnumerable<StatisticDto> Statistics { get; }
        void GetStatistics(IHaveCarInformation request);
    }
}
