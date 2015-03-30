using System;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.Identifiers
{
    [Serializable]
    [DataContract]
    public class ServerIdentifier
    {
        [DataMember]
        public string MachineName { get; set; }
        [DataMember]
        public string LocalIP { get; set; }

        public ServerIdentifier()
        {
        }

        private ServerIdentifier(string machineName, string localIP)
        {
            MachineName = machineName;
            LocalIP = localIP;
        }

        public static ServerIdentifier Create()
        {
            var localIP = string.Empty;
            var host = Dns.GetHostEntry(Dns.GetHostName());
            foreach (var ip in host.AddressList.Where(ip => ip.AddressFamily == AddressFamily.InterNetwork))
            {
                localIP = ip.ToString();
                break;
            }

            return new ServerIdentifier(Environment.MachineName, localIP);
        }
    }
}