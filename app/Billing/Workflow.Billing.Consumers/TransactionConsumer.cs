using Billing.Domain.Core.Repositories;
using EasyNetQ.AutoSubscribe;
using Shared.Messaging.Billing.Messages;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Consumers
{
    public class TransactionConsumer : IConsume<TransactionMessage>
    {
        public void Consume(TransactionMessage message)
        {
            var test = message;
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