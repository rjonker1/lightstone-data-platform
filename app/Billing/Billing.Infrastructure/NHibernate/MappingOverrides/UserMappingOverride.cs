using Billing.Domain.Entities.DemoEntities;
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;

namespace Billing.Infrastructure.NHibernate.MappingOverrides
{
    public class UserMappingOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.HasMany(x => x.Transactions).Cascade.All();
        }
    }
}