using System;

namespace Api.Domain.Infrastructure.Dto
{
    public class ValidationDto
    {
        public Guid Id { get; set; }
        public string CommercialStateValue { get; set; }
        public DateTime? TrialExpiration { get; set; }
        public bool? IsActive { get; set; }
        public bool IsLocked { get; set; }
    }
}