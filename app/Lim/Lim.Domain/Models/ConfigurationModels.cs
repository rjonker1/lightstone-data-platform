using System;

namespace Lim.Domain.Models
{
    public class FrequencyType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class FrequencyConfiguration
    {
        public long Id { get; set; }
        public int Seconds { get; set; }
       
        public int Minutes { get; set; }
      
        public int Hours { get; set; }
       
        public string DayOfMonth { get; set; }
       
        public string Month { get; set; }
       
        public string DayofWeek { get; set; }
    }

    public class Actions
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class IntegrationType
    {
        public int Id { get; set; }
        public string Type { get; set; }
    }

    public class AuthenticationType
    {
         public int Id { get; set; }
        public string Type { get; set; }
    }

    public class IntegrationPackages
    {
        public long Id { get; set; }
        public long ConfigurationId { get; set; }
        public Guid PackageId { get; set; }
    }

    public class Configuration
    {
        public long Id { get; set; }
        public Guid Key { get; set; }
        public int FrequencyType { get; set; }
        public int Action { get; set; }
        public int IntegrationType { get; set; }
        public string BaseAddress { get; set; }
        public string Suffix { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool HasAuthentication { get; set; }
        public int AuthenticationType { get; set; }
        public Guid ClientId { get; set; }
        public Guid ContractId { get; set; }
        public string AccountNumber { get; set; }
        public int FrequencyConfigurationId { get; set; }
        public int Packages { get; set; }

    }

    public class AuditPush
    {
        public long Id { get; set; }
        public long ConfigurationId { get; set; }
        public long IntegrationType { get; set; }
        public DateTime PushedDate { get; set; }
        public string Payload { get; set; }
    }

    public class AuditPull
    {
        public long Id { get; set; }
        public long ConfigurationId { get; set; }
        public long IntegrationType { get; set; }
        public DateTime PulledDate { get; set; }
        public string Payload { get; set; }
    }
}
