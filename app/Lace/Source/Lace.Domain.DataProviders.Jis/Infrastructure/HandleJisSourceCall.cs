using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Jis.Infrastructure
{
    public class HandleJisSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromJisSource());
        }
    }
}
