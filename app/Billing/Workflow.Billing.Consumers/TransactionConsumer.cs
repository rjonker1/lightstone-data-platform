using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Billing.Domain.Core.Repositories;
using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers
{
    public class TransactionConsumer : IConsume<TransactionMessage>
    {
        private readonly IRepository<Transaction> _transactions;
        private readonly IRepository<UserMeta> _users;
        private readonly IRepository<PreBilling> _preBillingRepository;

        public TransactionConsumer(IRepository<Transaction> transactions, IRepository<UserMeta> users, IRepository<PreBilling> preBillingRepository)
        {
            _transactions = transactions;
            _users = users;
            _preBillingRepository = preBillingRepository;
        }

        public void Consume(TransactionMessage message)
        {
            var test = message;

            if (_transactions.Any(x => x.Id == message.Id))
            {
                foreach (var transaction in _transactions)
                {
                    //Logic to build up Denomalized data structure for new transaction
                    var customerUsers = _users.Where(x => x.Id == transaction.UserId);

                    //Mappings for User, Customer, Products(Dataproviders), Transaction
                    //Build up entity with each mapping
                    var preBillingEntity = Mapper.Map<IEnumerable<UserMeta>, PreBilling>(customerUsers);
                }
            }
        }
    }
}


//private readonly IRepository<UserMeta> _repository;
//private readonly IRepository<Transaction> _transactions;

//private readonly IRepository<PreBilling> _preBillings; 

//public TransactionConsumer(IRepository<UserMeta> repository)//, IRepository<Transaction> transactions, IRepository<PreBilling> preBillings)
//{
//    _repository = repository;
//    //_transactions = transactions;
//    //_preBillings = preBillings;


//    ////Add User transaction to customer in billing
//    ////TODO: Build up based per customer

//    var customerUsers = _repository.Where(x => true);
//    //var customerTransactions = _transactions.Where(t => customerUsers.Any(u => u.Id == t.UserId));

//    //var test = new PreBillingDto(customerUsers);//, customerTransactions);
//    var preBillingEntity = Mapper.Map<IEnumerable<UserMeta>, PreBilling>(customerUsers);

//    _preBillings.SaveOrUpdate(preBillingEntity);

//}

//public TransactionConsumer()
//{

//}