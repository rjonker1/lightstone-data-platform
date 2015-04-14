using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Messaging.Billing.Messages;
using DataPlatform.Shared.Repositories;
using EasyNetQ;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers
{
    public class TransactionConsumer //: IConsume<InvoiceTransactionCreated>
    {
        private readonly IRepository<Transaction> _transactions;
        private readonly IRepository<DataProviderTransaction> _dataProviderTransactions;
        private readonly IRepository<UserMeta> _users;
        private readonly IRepository<Product> _products;
        private readonly IRepository<PreBilling> _preBillingRepository;

        public TransactionConsumer(IRepository<Transaction> transactions, IRepository<UserMeta> users,
                                    IRepository<PreBilling> preBillingRepository,
                                    IRepository<DataProviderTransaction> dataProviderTransactions,
                                    IRepository<Product> products,
                                    IMessage<InvoiceTransactionCreated> message)
        {
            _transactions = transactions;
            _users = users;
            _preBillingRepository = preBillingRepository;
            _dataProviderTransactions = dataProviderTransactions;
            _products = products;

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
                    var preBillingEntity = Mapper.Map<IEnumerable<UserMeta>, PreBilling>(customerUsers);

                    var transactionProducts = _dataProviderTransactions.Where(x => x.RequestId == transaction.RequestId && x.Action == "Response");
                    var transactionEntities = Mapper.Map<IEnumerable<DataProviderTransaction>, IEnumerable<Product>>(transactionProducts);

                    _products.Save(transactionEntities);

                    //Mappings for User, Customer, Products(Dataproviders), Transaction
                    //Build up entity with each mapping
                    


                    preBillingEntity.CustomerAccountId = transaction.AccountNumber;
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