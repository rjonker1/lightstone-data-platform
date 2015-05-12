﻿using System;
using System.Collections;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Entities
{
    public class UserBillingTransaction<T> : ICommitBillingTransaction<UserTransactionModelDto>
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;

        public UserBillingTransaction(IRepository<StageBilling> stageBillingRepository)
        {
            _stageBillingRepository = stageBillingRepository;
        }

        public void Commit(UserTransactionModelDto userTransactions)
        {
            foreach (var userTransaction in userTransactions.Transactions)
            {
                var transactionRequests = _stageBillingRepository.Where(x => x.RequestId == userTransaction.RequestId);

                foreach (var transactionRequest in transactionRequests)
                {
                    transactionRequest.IsBillable = userTransaction.IsBillable;
                    transactionRequest.Modified = DateTime.UtcNow;
                    transactionRequest.ModifiedBy = "dev.billing.api.lightstone.co.za";

                    _stageBillingRepository.SaveOrUpdate(transactionRequest);
                }

            }
        }

    }
}