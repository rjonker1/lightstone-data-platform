using System;

namespace Billing.Api.Dtos
{
    public class CreateTransaction
    {
        public Guid UserId { get; private set; }
    }
}
