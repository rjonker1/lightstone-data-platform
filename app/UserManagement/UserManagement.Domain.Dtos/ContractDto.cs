using System;

namespace UserManagement.Domain.Dtos
{
    public class ContractDto
    {
        public Guid Id { get; set; }
        public DateTime CommencementDate { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string EnteredIntoBy { get; set; }
        public DateTime? OnlineAcceptance { get; set; }
        public string RegisteredName { get; set; }
        public string RegistrationNumber { get; set; }
        public Guid ContractTypeId { get; set; }
        public Guid EscalationTypeId { get; set; }
        public Guid ContractDurationId { get; set; }
    }
}