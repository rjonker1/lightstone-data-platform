using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure
{
    public sealed class HandleLightstoneCompanyCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromLightstoneCompany());
        }
    }
}
