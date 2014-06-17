using System;

namespace Lace.Source.Tests.Data.IvidTitleHolder
{
    public class MockHandleIvidTitleHolderServiceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new MockRequestDataFromIvidTitleHolderService());
        }
    }
}
