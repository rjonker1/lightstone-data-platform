using System;
using System.Collections;
using System.Configuration;
using Cradle.KeepAlive.Service.Helpers.Notifications;
using RestSharp;

namespace Cradle.KeepAlive.Service.Helpers
{
    public class HealthCheck
    {
        private readonly CheckEndpoint _checkEndpoint = new CheckEndpoint();
        private readonly ISendNotifications _emailNotifications;

        public HealthCheck(ISendNotifications emailNotifications)
        {
            _emailNotifications = emailNotifications;
        }

        public void PingDataPlatform()
        {
            var statusCheckList = new Hashtable();

            foreach (string key in ConfigurationManager.AppSettings)
            {
                if (key.StartsWith("endpoint/url"))
                {
                    var status = _checkEndpoint.Invoke("", ConfigurationManager.AppSettings[key], "ping", Method.GET);
                    statusCheckList.Add(ConfigurationManager.AppSettings[key], (int)status);
                }
            }

            foreach (DictionaryEntry endPointStatus in statusCheckList)
            {
                Console.WriteLine(endPointStatus.Key + " - " + endPointStatus.Value);
            }
        } 
    }
}