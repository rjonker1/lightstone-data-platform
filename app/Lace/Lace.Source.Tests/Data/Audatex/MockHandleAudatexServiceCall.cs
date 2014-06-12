using System;

namespace Lace.Source.Tests.Data.Audatex
{
    public class MockHandleAudatexServiceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new MockRequestDataFromAudatexService());
        }
    }
}
