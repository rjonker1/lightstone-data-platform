using Lace.Domain.DataProviders.RgtVin.RgtVinServiceReference;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure.Configuration
{
    public class ConfigureRgtVinWebSource
    {
        public wsVinCheckSoapClient RgtVinServiceProxy
        {
            get
            {
                return new wsVinCheckSoapClient();
            }
        }


        public void CloseWebService()
        {
            if(RgtVinServiceProxy == null)return;

            RgtVinServiceProxy.Close();
        }
    }
}
