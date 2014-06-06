using System;
using System.Configuration;

namespace Billing.Api.Connector.Configuration
{
    /// <summary>
    /// This configuration reads the following keys from the *.config file:
    /// billing/url - base url for the billing API - end the value with /
    /// billing/apiKey - the apikey to use when talking to the billing api
    /// </summary>
    public class ApplicationConfigurationBillingConnectorConfiguration : IBillingConnectorConfiguration
    {
        private const string apiKeyKey = "billing/apiKey";
        private const string urlKey = "billing/url";

        public string Url
        {
            get { return GetKey(urlKey); }
        }

        public string ApiKey
        {
            get { return GetKey(apiKeyKey); }
        }

        private string GetKey(string key)
        {
            var keyValue = ConfigurationManager.AppSettings[urlKey];
            if (string.IsNullOrEmpty(keyValue))
            {
                throw new Exception(string.Format("Failed to get {0} from the application configuration", key));
            }

            return keyValue;
        }
    }
}