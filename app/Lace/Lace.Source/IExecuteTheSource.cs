using Lace.Events;
using Lace.Models.Responses;

namespace Lace.Source
{
    public interface IExecuteTheSource
    {
        void CallSource(ILaceResponse response, ILaceEvent laceEvent);
    }
}
