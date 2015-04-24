using System.Collections.Generic;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts.Requests;

namespace Lace.Domain.Core.Contracts.DataProviders
{
    public interface IProvideDataFromLightstoneProperty : IPointToLaceProvider
    {
        IAmLightstonePropertyRequest Request { get; }
        IEnumerable<IRespondWithProperty> PropertyInformation { get; }
    }
}