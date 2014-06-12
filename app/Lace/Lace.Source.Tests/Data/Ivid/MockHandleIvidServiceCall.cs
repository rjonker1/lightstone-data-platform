using System;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockHandleIvidServiceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new MockRequestDataFromIvidService());
        }
    }
}
