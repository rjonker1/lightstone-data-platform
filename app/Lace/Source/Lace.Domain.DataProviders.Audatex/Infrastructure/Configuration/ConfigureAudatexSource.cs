using Lace.Domain.DataProviders.Audatex.AudatexServiceReference;

namespace Lace.Domain.DataProviders.Audatex.Infrastructure.Configuration
{
    public class ConfigureAudatexSource
    {
        public BackOfficeWebServiceSoapClient AudatexServiceProxy { get; private set; }

        public ConfigureAudatexSource Create()
        {
            AudatexServiceProxy = new BackOfficeWebServiceSoapClient();
            return this;
        }

        public void Close()
        {
            if (AudatexServiceProxy == null) return;

            AudatexServiceProxy.Close();
        }
    }
}
