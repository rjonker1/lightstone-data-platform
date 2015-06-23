using UserManagement.Domain.Core.Entities;
using IEntity = DataPlatform.Shared.Entities.IEntity;
using INamedEntity = DataPlatform.Shared.Entities.INamedEntity;

namespace UserManagement.Domain.Entities
{
    public class ContractBundle : NamedEntity, INamedEntity, IEntity
    {
        public virtual double Price { get; set; }
        public virtual int TransactionLimit { get; set; }

        public ContractBundle() { }

        public ContractBundle(double price, int transactionLimit, string name) : base (name)
        {
            Name = name;
            Price = price;
            TransactionLimit = transactionLimit;
        }
    }
}