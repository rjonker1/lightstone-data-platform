using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Anpr.Infrastructure
{
    public class HandleAnprSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromAnprSource());
        }
    }
}
