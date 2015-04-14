﻿using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using EasyNetQ.AutoSubscribe;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers
{
    public class TransactionConsumer //: IConsume<InvoiceTransactionCreated>
    {
        private readonly IRepository<Transaction> _transactions;
        private readonly IRepository<UserMeta> _users;
        private readonly IRepository<PreBilling> _preBillingRepository;

        public TransactionConsumer(IRepository<Transaction> transactions, IRepository<UserMeta> users,
                                    IRepository<PreBilling> preBillingRepository, IMessage<InvoiceTransactionCreated> message)
        {
            _transactions = transactions;
            _users = users;
            _preBillingRepository = preBillingRepository;

            Consume(message);
        }

        public void Consume(IMessage<InvoiceTransactionCreated> message)
        {
            var transactionId = message.Body.TransactionId;

            if (_transactions.Any(x => x.Id == transactionId))
            {
                foreach (var transaction in _transactions)
                {
                    //Logic to build up Denomalized data structure for new transaction
                    var customerUsers = _users.Where(x => x.Id == transaction.UserId);

                    //Mappings for User, Customer, Products(Dataproviders), Transaction
                    //Build up entity with each mapping
                    var preBillingEntity = Mapper.Map<IEnumerable<UserMeta>, PreBilling>(customerUsers);
                    preBillingEntity.CustomerName = "ACC NUMBER MAPPING";
                    _preBillingRepository.Save(preBillingEntity);
                }

                return;
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