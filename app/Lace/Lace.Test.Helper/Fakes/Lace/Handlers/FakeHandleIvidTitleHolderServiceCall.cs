using System;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Test.Helper.Builders.Sources;

namespace Lace.Test.Helper.Fakes.Lace.Handlers
{
    public class FakeHandleIvidTitleHolderServiceCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromSourceBuilder().ForIvidTitleHolder());
        }
    }
}
