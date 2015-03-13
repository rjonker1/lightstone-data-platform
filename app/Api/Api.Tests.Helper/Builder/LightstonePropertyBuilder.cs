using System.Collections.ObjectModel;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
namespace Api.Tests.Helper.Builder
{
    public class LightstonePropertyBuilder
    {
        public Collection<IPointToLaceProvider> ForLightstonePropertyResponse()
        {
            return new Collection<IPointToLaceProvider>()
            {
                new LightstonePropertyResponse()
            };
        }
    }
}