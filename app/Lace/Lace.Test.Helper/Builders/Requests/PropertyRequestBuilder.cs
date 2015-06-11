
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Test.Helper.Mothers.Requests.PropertyRequests;

namespace Lace.Test.Helper.Builders.Requests
{
    public class PropertyRequestBuilder
    {
        public ICollection<IPointToLaceRequest> ForPropertySources()
        {
            return new Collection<IPointToLaceRequest>() { new PropertiesRequest() };
        }

    }
}
