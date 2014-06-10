using System;
namespace Lace.Source.Tests.Data.RgtVin
{
    public class MockHandleRgtVinServiceCall : IHandleServiceCall
    {
        public void Request(Action<IRequestDataFromService> action)
        {
            action(new MockRequestDataFromRgtVinHolderService());
        }
    }
}
