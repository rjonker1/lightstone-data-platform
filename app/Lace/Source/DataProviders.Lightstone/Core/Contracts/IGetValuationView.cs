using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetValuationView
    {
        List<Sale> Sales { get; }
        List<StatisticDto> Statistics { get; }
        void GetValuation(IHaveCarInformation request);
    }
}
