using Billing.Domain.Core.Entities;
using Billing.Domain.Entities.DemoEntities;

namespace Billing.Domain.Entities
{
    public class PreBilling : Entity
    {
        //public virtual IEnumerable<User> Users { get; protected internal set; }
        public virtual string Type { get; protected internal set; }
        public virtual string Owner { get; protected internal set; }
        //public virtual IEnumerable<Product> Products { get; protected internal set; }
        //public virtual IEnumerable<TransactionMocks> Transactions { get; protected internal set; }
        public virtual string UserType { get; protected internal set; }
        public virtual int Total { get; protected internal set; }

        public PreBilling() { }

        //public PreBilling()
        //{
        //    //Mock data
        //    Id = Guid.NewGuid();
        //    CustomerName = "CUST01";
        //    NumUsers = new User();
        //    Type = "Type123";
        //    Owner = "Testeroonie";
        //    NumProducts = new Product();
        //    NumTransactions = new TransactionMocks();
        //    UserType = "User Type 1";
        //    Total = 123;
        //}

        //public PreBilling(Guid id, string customerName, User numUsers, string type, string owner, Product numProducts, TransactionMocks numTransactions, string userType, int total)
        //    : base(id)
        //{
        //    CustomerName = customerName;
        //    NumUsers = numUsers;
        //    Type = type;
        //    Owner = owner;
        //    NumProducts = numProducts;
        //    NumTransactions = numTransactions;
        //    UserType = userType;
        //    Total = total;
        //}
    }
}