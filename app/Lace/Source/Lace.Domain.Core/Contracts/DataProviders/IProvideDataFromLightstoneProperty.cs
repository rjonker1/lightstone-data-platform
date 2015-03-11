using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneProperty : IPointToLaceProvider
    {
        IEnumerable<IRespondWithProperty> PropertyInformation { get; }
    }
}