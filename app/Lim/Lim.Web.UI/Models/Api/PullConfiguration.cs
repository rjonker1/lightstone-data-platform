using System;
using System.Collections.Generic;
using System.Linq;
using Lim.Enums;
using Lim.Web.UI.Commands;
using Lim.Web.UI.Handlers;

namespace Lim.Web.UI.Models.Api
{
    public class PullConfiguration
    {
        public PullConfiguration()
        {
            
        }
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

        public IReadOnlyCollection<AuthenticationType> Authentication;

        public IReadOnlyCollection<FrequencyType> Frequency;
        public void SetClients(IHandleGettingClient handler, GetClients command)
        {
            handler.Handle(command);
            SelectableClients = command.Clients.ToList();
        }

        public void SetAuthentication(IHandleGettingConfiguration handler, GetAuthenticationTypes command)
        {
            handler.Handle(command);
            Authentication = command.Authentication.ToList();
        }

        public void SetFrequency(IHandleGettingConfiguration handler, GetFrequencyTypes command)
        {
            handler.Handle(command);
            Frequency = command.Frequency.ToList();
        }

        //public IReadOnlyCollection<AuthenticationType> Authentication = Enum.GetValues(typeof(Enums.AuthenticationType))
        //    .Cast<Enums.AuthenticationType>()
        //    .Select(s => new AuthenticationType((int)s, s.ToString()))
        //    .ToList();

        //public IReadOnlyCollection<FrequencyType> Frequency = Enum.GetValues(typeof(Frequency))
        //    .Cast<Frequency>()
        //    .Select(s => new FrequencyType((int)s, s.ToString()))
        //    .ToList();
    }
}