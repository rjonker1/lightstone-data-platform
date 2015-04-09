using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration
{
    public class ConfigureAudatex
    {
        public BackOfficeWebServiceSoapClient Client { get; private set; }

        public ConfigureAudatex Create()
        {
            Client = new BackOfficeWebServiceSoapClient();
            return this;
        }

        public void Close()
        {
            if (Client == null) return;

            Client.Close();
        }
    }
}
