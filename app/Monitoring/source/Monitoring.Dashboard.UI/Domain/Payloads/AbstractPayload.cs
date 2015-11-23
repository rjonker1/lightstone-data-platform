using System.Text;

namespace Monitoring.Dashboard.UI.Domain.Payloads
{
    public interface IPayloadIndicator
    {
        void DeserializePayload(byte[] payload);
    }

    public class AbstractPayload : IPayloadIndicator
    {
        protected string JsonPayload;

        public AbstractPayload()
        {
            
        }

        public void DeserializePayload(byte[] payload)
        {
            JsonPayload = payload == null ? string.Empty : Encoding.UTF8.GetString(payload);
        }
    }
}