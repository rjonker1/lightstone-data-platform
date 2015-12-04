using System.Runtime.Serialization;
using DataProviders.Xds.IdentityVerification.XdsServiceReference;
using Lace.Domain.DataProviders.Core.Configuration;

namespace DataProviders.Xds.IdentityVerification.Infrastructure.Configuration
{
    public class ConfigureApi
    {
        //Username: light1
        //    Password: beybzn
        public readonly string Username = XdsConfiguration.Username;
        public readonly string Password = XdsConfiguration.Password;
        public readonly string Ticket;

        public ConfigureApi()
        {
            Client = new XDSConnectWSSoapClient();
            Ticket = Client.Login(Username, Password);
        }

        [DataMember]
        public XDSConnectWSSoapClient Client { get; private set; }
    }
}
