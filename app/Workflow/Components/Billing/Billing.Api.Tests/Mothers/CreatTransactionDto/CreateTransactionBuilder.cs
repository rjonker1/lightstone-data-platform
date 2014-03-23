using System;
using Billing.Api.Dtos;

namespace Billing.Api.Tests.Mothers.CreatTransactionDto
{
    public class CreateTransactionBuilder
    {
        private Guid userId;
        private Guid transactionId;

        public CreateTransactionBuilder WithUserId(Guid userId)
        {
            this.userId = userId;
            return this;
        }

        public CreateTransactionBuilder WithTransactionId(Guid transactionId)
        {
            this.transactionId = transactionId;
            return this;
        }

        public CreateTransaction Build()
        {
            return new CreateTransaction(userId, transactionId);
        }

        public CreateTransaction Build(IDefineCreateTransactionData data)
        {
            return WithUserId(data.UserId)
                .WithTransactionId(data.TransactionId)
                .Build();
        }
    }
}