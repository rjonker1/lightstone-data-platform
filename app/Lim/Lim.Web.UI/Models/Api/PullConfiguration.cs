using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Enums;

namespace Lim.Web.UI.Models.Api
{
    public class PullConfiguration
    {
        public PullConfiguration(Configuration configuration)
        {
            Configuration = configuration;
        }

        public PullConfiguration(Configuration configuration, long configurationApiId)
        {
            ConfigurationApiId = configurationApiId;
            Configuration = configuration;
        }

        public Configuration Configuration { get; private set; }
        public long ConfigurationApiId { get; private set; }
        public string BaseAddress { get; set; }
        public string Suffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAuthentication { get; set; }
        public string AuthenticationToken { get; set; }
        public string AuthenticationKey { get; set; }
        public int AuthenticationType { get; set; }

        public IReadOnlyCollection<Client> SelectableClients;
        public void SetClients(List<Client> clients)
        {
            SelectableClients = clients;
        }

        public IReadOnlyCollection<AuthenticationType> Authentication = Enum.GetValues(typeof(Enums.AuthenticationType))
            .Cast<Enums.AuthenticationType>()
            .Select(s => new AuthenticationType((int)s, s.ToString()))
            .ToList();

        public IReadOnlyCollection<FrequencyType> Frequency = Enum.GetValues(typeof(Frequency))
            .Cast<Frequency>()
            .Select(s => new FrequencyType((int)s, s.ToString()))
            .ToList();
    }
}