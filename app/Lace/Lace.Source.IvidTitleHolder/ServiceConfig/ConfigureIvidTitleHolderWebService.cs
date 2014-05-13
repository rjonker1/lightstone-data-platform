using System;
using System.Net;
using System.ServiceModel.Channels;
using System.Text;
using Lace.Source.IvidTitleHolder.IvidTitleHolderServiceReference;

namespace Lace.Source.IvidTitleHolder.ServiceConfig
{
    public class ConfigureIvidTitleHolderWebService
    {
        private readonly string _userName =
            Configuration.AppSettings.DefaultAppSettingConfiguration.GetSetting("IvidTitleHolderServiceUserName");

        private readonly string _userPassowrd =
            Configuration.AppSettings.DefaultAppSettingConfiguration.GetSetting("IvidTitleHolderServiceUserPassword");

        public IvidTitleholderServiceClient IvidTitleHolderProxy { get; private set; }
        public HttpRequestMessageProperty IvidTitleHolderRequestMessageProperty { get; private set; }

        public void ConfigureIvidTitleHolderServiceCredentials()
        {
            IvidTitleHolderProxy = new IvidTitleholderServiceClient();

            if (IvidTitleHolderProxy == null || IvidTitleHolderProxy.ClientCredentials == null)
                throw new Exception("Cannot configure Ivid Title Holder Service");

            IvidTitleHolderProxy.ClientCredentials.UserName.UserName = _userName;
            IvidTitleHolderProxy.ClientCredentials.UserName.Password = _userPassowrd;
        }

        public void ConfigureIvidTitleHolderWebServiceRequestMessageProperty()
        {
            IvidTitleHolderRequestMessageProperty = new HttpRequestMessageProperty();
            IvidTitleHolderRequestMessageProperty
                .Headers[HttpRequestHeader.Authorization] = string.Format("Basic {0}",
                    Convert.ToBase64String(Encoding.ASCII.GetBytes(string.Format("{0}:{1}", _userName, _userPassowrd))));
        }

        public void CloseWebService()
        {
            if (IvidTitleHolderProxy == null) return;

            IvidTitleHolderProxy.Close();
        }
    }
}
