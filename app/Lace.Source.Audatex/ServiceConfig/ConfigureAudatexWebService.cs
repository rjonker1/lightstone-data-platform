using Lace.Source.Audatex.AudatexServiceReference;

namespace Lace.Source.Audatex.ServiceConfig
{
    public class ConfigureAudatexWebService
    {
        public BackOfficeWebServiceSoapClient AudatexServiceProxy
        {
            get
            {
                return new BackOfficeWebServiceSoapClient();
            }
        }

        public void CloseWebService()
        {
            if (AudatexServiceProxy == null) return;

            AudatexServiceProxy.Close();
        }
    }
}
