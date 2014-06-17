using System;
namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockHandleRgtVinServiceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new MockRequestDataFromRgtVinHolderService());
        }
    }
}
