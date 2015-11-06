using System;
using System.Collections.Generic;

namespace Cradle.KeepAlive.Service.Domain.Dtos
{
    public class ConsumerDto
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string Token { get; set; }
        public IEnumerable<CustomerDto> Customers { get; set; }
        public IEnumerable<ClientDto> Clients { get; set; } 
    }
}