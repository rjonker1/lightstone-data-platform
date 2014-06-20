using Lace.Events;
using Lace.Response;

namespace Lace.Source
{
    public interface IExecuteTheSource
    {
        void CallSource(ILaceResponse response, ILaceEvent laceEvent);
    }
}
