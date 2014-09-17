using Lace.Events;
using Lace.Models;

namespace Lace.Consumer
{
    public interface IConsumeSource
    {
        void ConsumeExternalSource(IProvideLaceResponse response, ILaceEvent laceEvent);
    }
}
