using System;
using System.Collections.Generic;

namespace Workflow.Billing.Domain.Dtos
{
    public class UserDto
    {
        public Guid UserId { get; set; }
        public string Username { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public IEnumerable<TransactionDto> Transactions { get; set; }
    }
}