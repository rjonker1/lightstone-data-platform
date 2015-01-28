using System;
using UserManagement.Domain.Core.Commands;

namespace UserManagement.Domain.Entities.Commands.PaymentTypes
{
    public class CreatePaymentType : DomainCommand
    {

        public string Name;

        public CreatePaymentType(string name)
        {
            Id = Guid.NewGuid();
            Name = name;
        }
    }
}