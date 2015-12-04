using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace DataProviders.Xds.IdentityVerification.Infrastructure
{
    public class HandleXdsIdVerificationCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
           action(new RequestDataFromXds());
        }
    }
}