using Lace.Events;
using Lace.Models.Responses;

namespace Lace.Consumer
{
    public interface IConsumeSource
    {
        void ConsumeExternalSource(ILaceResponse response, ILaceEvent laceEvent);
    }
}
