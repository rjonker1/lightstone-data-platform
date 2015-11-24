using System.Text;

namespace Monitoring.Domain
{
    public interface IDto
    {
        void Deserialize(byte[] payload);
    }

    public class AbstractDto : IDto
    {
        protected string JsonPayload;

        public AbstractDto()
        {
            
        }

        public void Deserialize(byte[] payload)
        {
            JsonPayload = payload == null ? string.Empty : Encoding.UTF8.GetString(payload);
        }
    }
}