using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public class SourceConsumer : ExecuteSourceBase, IExecuteTheSource
    {
        public SourceConsumer(IExecuteTheSource source, IExecuteTheSource fallbackSource)
            : base(source, fallbackSource)
        {
           
        }

        public void CallSource(ILaceResponse response, ILaceEvent laceEvent)
        {
            Next.CallSource(response, laceEvent);
        }
    }
}
