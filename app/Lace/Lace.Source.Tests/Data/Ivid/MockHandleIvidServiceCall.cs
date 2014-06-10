using System;

namespace Lace.Source.Tests.Data.Ivid
{
    public class MockHandleIvidServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new MockRequestDataFromIvidService());
        }
    }
}
