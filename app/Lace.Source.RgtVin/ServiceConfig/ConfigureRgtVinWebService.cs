using Lace.Source.RgtVin.RgtVinServiceReference;

namespace Lace.Source.RgtVin.ServiceConfig
{
    public class ConfigureRgtVinWebService
    {
        public wsVinCheckSoapClient RgtVinServiceProxy { get; private set; }

        public ConfigureRgtVinWebService()
        {
            RgtVinServiceProxy = new wsVinCheckSoapClient();
        }
        
        public void CloseWebService()
        {
            if(RgtVinServiceProxy == null)return;

            RgtVinServiceProxy.Close();
        }
    }
}
