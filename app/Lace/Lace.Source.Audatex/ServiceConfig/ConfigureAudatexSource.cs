using Lace.Source.Audatex.AudatexServiceReference;

namespace Lace.Source.Audatex.ServiceConfig
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
