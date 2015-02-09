using System;

namespace UserManagement.Domain.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public string CustomerName { get; set; }
        public string AccountOwnerName { get; set; }
        public Guid CommercialStateId { get; set; }
        public Guid CreateSourceId { get; set; }
        public Guid PlatformStatusId { get; set; }
        //public Guid ProvinceId { get; set; }
    }
}