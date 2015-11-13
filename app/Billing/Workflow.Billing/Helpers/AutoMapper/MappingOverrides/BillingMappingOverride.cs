using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.AutoMapper.MappingOverrides
{
    public class BillingMappingOverride : IAutoMappingOverride<BillingTransaction>
    {
        public void Override(AutoMapping<BillingTransaction> mapping)
        {
            mapping.DiscriminateSubClassesOnColumn("Type").Index("Type"); //, @"null").SqlType("VARCHAR").Not.Nullable().Length(128);
            mapping.Map(x => x.CustomerId).Index("CustomerId");
            mapping.Map(x => x.ClientId).Index("ClientId");
            mapping.Map(x => x.BillingType).Index("BillingType");

            mapping.Component(x => x.Package, m =>
            {
                m.Map(x => x.PackageId);
                m.Map(x => x.PackageName);
                m.Map(x => x.PackageCostPrice);
                m.Map(x => x.PackageRecommendedPrice);
            });

            mapping.Component(x => x.DataProvider, m =>
            {
                m.Map(x => x.DataProviderId);
                m.Map(x => x.DataProviderName);
                m.Map(x => x.CostPrice);
                m.Map(x => x.RecommendedPrice);
                m.Map(x => x.ResponseState);
                m.Map(x => x.TransactionState);
            });

            mapping.Component(x => x.UserTransaction, m =>
            {
                m.Map(x => x.RequestId);
                m.Map(x => x.TransactionId);
                m.Map(x => x.IsBillable);
            });

            mapping.Component(x => x.User, m =>
            {
                m.Map(x => x.UserId);
                m.Map(x => x.Username);
                m.Map(x => x.FirstName);
                m.Map(x => x.LastName);
                m.Map(x => x.HasTransactions);
            });
        }
    }
}