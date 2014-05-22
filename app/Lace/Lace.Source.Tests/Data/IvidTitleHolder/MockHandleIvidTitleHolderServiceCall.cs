using System;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockHandleIvidTitleHolderServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new MockRequestDataFromIvidTitleHolderService());
        }
    }
}
