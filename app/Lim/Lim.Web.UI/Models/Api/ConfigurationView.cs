using System;
using System.Collections.Generic;
using Lim.Enums;

namespace Lim.Web.UI.Models.Api
{
    public class ConfigurationView
    {
        public ConfigurationView()
        {
            
        }
        public ConfigurationView(Configuration configuration, string clientName)
        {
            Configuration = configuration;
            ClientName = clientName;
        }

        public static List<ConfigurationView> Get()
        {
            return new List<ConfigurationView>()
            {
                new ConfigurationView(
                    new Configuration(1000, Guid.NewGuid(), (int) IntegrationAction.Push, (int) Enums.IntegrationType.Api, (int) Enums.Frequency.Daily,
                        new Guid("85FA96F5-771C-45C2-B588-A9C906789561"), new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"), "ABC 0001", true),
                    "ABC Client"),
                new ConfigurationView(
                    new Configuration(2000, Guid.NewGuid(), (int) IntegrationAction.Pull, (int) Enums.IntegrationType.Api, (int) Enums.Frequency.Hourly,
                        new Guid("85FA96F5-771C-45C2-B588-A9C906789561"), new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"), "DEF 0002", true),
                    "DEF Client")
            };
        }

        public Configuration Configuration { get; private set; }

        public string ClientName { get; private set; }
        public string Action {
            get
            {
                return ((IntegrationAction) Configuration.ActionType).ToString();
            }
        }

        public string Frequency
        {
            get
            {
                return ((Enums.Frequency) Configuration.FrequencyType).ToString();
            }
        }

        public string Type
        {
            get
            {
                return ((Enums.IntegrationType)Configuration.IntegrationType).ToString();
            }
        }
    }
}