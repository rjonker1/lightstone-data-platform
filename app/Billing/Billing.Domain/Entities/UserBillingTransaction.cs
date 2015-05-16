using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Billing.Domain.Dtos;
using DataPlatform.Shared.Repositories;
using Workflow.Billing.Domain.Entities;

namespace Billing.Domain.Entities
{
    public class UserBillingTransaction<T> : ICommitBillingTransaction<UserTransactionDto>
    {
        private readonly IRepository<StageBilling> _stageBillingRepository;
        private readonly IRepository<AuditLog> _auditLogs;

        public string CurrentUser;

        public UserBillingTransaction(IRepository<StageBilling> stageBillingRepository, IRepository<AuditLog> auditLogs)
        {
            _stageBillingRepository = stageBillingRepository;
            _auditLogs = auditLogs;
        }

        public void Commit(UserTransactionDto userTransactions)
        {

            var auditLogsList = new List<AuditLog>();

            foreach (var userTransaction in userTransactions.Transactions)
            {
                var transactionRequests = _stageBillingRepository.Where(x => x.RequestId == userTransaction.RequestId);

                foreach (var transactionRequest in transactionRequests)
                {

                    if (transactionRequest.IsBillable != userTransaction.IsBillable)
                    {
                        var auditLog = new AuditLog
                        {
                            Id = Guid.NewGuid(),
                            TransactionId = transactionRequest.TransactionId,
                            RequestId = transactionRequest.RequestId,
                            Modified = DateTime.UtcNow,
                            ModifiedBy = userTransactions.UserName,
                            FieldName = "isBillable",
                            NewValue = userTransaction.IsBillable.ToString(),
                            OriginalValue = transactionRequest.IsBillable.ToString()
                        };

                        var logIndex = auditLogsList.FindIndex(x => x.TransactionId == transactionRequest.TransactionId);
                        if (logIndex < 0) auditLogsList.Add(auditLog);

                    }

                    transactionRequest.IsBillable = userTransaction.IsBillable;
                    transactionRequest.Modified = DateTime.UtcNow;
                    transactionRequest.ModifiedBy = CurrentUser;

                    _stageBillingRepository.SaveOrUpdate(transactionRequest);
                }

                auditLogsList.ForEach(x => _auditLogs.SaveOrUpdate(x));
            }
        }

    }
}