using System;
namespace Lim.Dtos
{
    public class AuditApiIntegrationDto
    {
        public long Id { get; protected set; }
        public  long ClientId { get; set; }
        public  long ConfigurationId { get; set; }
        public  short ActionType { get; set; }
        public  short IntegrationType { get; set; }
        public  DateTime Date { get; set; }
        public  bool WasSuccessful { get; set; }
        public  string Address { get; set; }
        public  string Suffix { get; set; }
        public  string Payload { get; set; }
    }
}
