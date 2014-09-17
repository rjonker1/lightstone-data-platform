using Lace.Events;
using Lace.Models;
namespace Lace.Source
{
    public interface IExecuteTheSource
    {
        void CallSource(IProvideLaceResponse response, ILaceEvent laceEvent);
    }
}
