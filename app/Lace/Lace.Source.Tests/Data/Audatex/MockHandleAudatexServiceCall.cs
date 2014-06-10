using System;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockHandleAudatexServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new MockRequestDataFromAudatexService());
        }
    }
}
