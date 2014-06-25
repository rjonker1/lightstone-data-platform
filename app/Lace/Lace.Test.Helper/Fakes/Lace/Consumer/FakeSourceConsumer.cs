using Lace.Events;
using Lace.Response;
using Lace.Source;

namespace Lace.Test.Helper.Fakes.Lace.Consumer
{
    public class FakeSourceConsumer: ExecuteSourceBase, IExecuteTheSource
    {
        public FakeSourceConsumer(IExecuteTheSource source, IExecuteTheSource fallbackSource)
            : base(source, fallbackSource)
        {
           
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            Next.CallSource(response, laceEvent);
        }
    }
}
