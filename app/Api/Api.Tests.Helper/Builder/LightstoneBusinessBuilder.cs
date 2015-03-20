using System.Collections.ObjectModel;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
namespace Api.Tests.Helper.Builder
{
    public class LightstoneBusinessBuilder
    {
        public Collection<IPointToLaceProvider> ForLightstoneBusinessResponse()
        {
            return new Collection<IPointToLaceProvider>()
            {
                new LightstoneBusinessResponse()
            };
        }
    }
}