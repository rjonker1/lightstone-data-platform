using System.Collections;
using System.Configuration;
using Cradle.KeepAlive.Service.Helpers;
using Cradle.KeepAlive.Service.Helpers.Notifications;
using DataPlatform.Shared.Helpers.Extensions;
using RestSharp;

namespace Cradle.KeepAlive.Service.Domain
{
    public class HealthCheck : EmailAlert
    {
        private readonly CheckEndpoint _checkEndpoint = new CheckEndpoint();

        public void PingDataPlatform()
        {
            var statusCheckList = new Hashtable();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.StartsWith("endpoint/url"))
                { 
                    var status = _checkEndpoint.Invoke("", ConfigurationManager.AppSettings[key], "ping", Method.GET);
                    this.Info(() => "Checked " + ConfigurationManager.AppSettings[key] + " - Status: " + status);
                    statusCheckList.Add(ConfigurationManager.AppSettings[key], (int)status);
                }
            }

            foreach (DictionaryEntry endPointStatus in statusCheckList)
            {
                if ((int)endPointStatus.Value != 200) SendEmail("API ALERT - " + endPointStatus.Key, 
                                                                        "API Endpoint: " + endPointStatus.Key + " returned the follow status code: " + endPointStatus.Value);
            }
        }
    }
}