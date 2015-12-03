using System;
using Lim.Enums;

namespace Lim.Dtos
{
    public class ConfigurationApiDto
    {
        public long Id { get; set; }
        public ConfigurationDto Configuration { get; set; }
        public string BaseAddress { get; set; }
        public string Suffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAuthentication { get; set; }
        public string AuthenticationToken { get; set; }
        public string AuthenticationKey { get; set; }
        public AuthenticationType AuthenticationType { get; set; }
        public DateTime? DateCreated { get; set; }
    }
}