using System.Collections.Generic;
using Lace.CrossCutting.DataProvider.Car.Core.Contracts;
using Lace.Toolbox.Database.Models;

namespace Lace.Domain.DataProviders.Lightstone.Core.Contracts
{
    public interface IGetMakes
    {
        IEnumerable<Make> Makes { get; }
        void GetMakes(IHaveCarInformation request);
    }
}
