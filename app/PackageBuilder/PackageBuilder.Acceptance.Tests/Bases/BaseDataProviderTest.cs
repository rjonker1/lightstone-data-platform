using System;
using System.Collections.Generic;
using System.Linq;
using Nancy.Testing;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.Requests;
using PackageBuilder.TestHelper.Helpers.Extensions;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Bases
{
    public abstract class BaseDataProviderTest : BaseModuleTest
    {
        protected Guid Id = Guid.NewGuid();
        protected DataProvider DataProvider;
        protected INEventStoreRepository<DataProvider> WriteRepo;
        protected IHandleMessages Handler;
        protected BrowserResponse Response;

        protected BaseDataProviderTest()
        {
            RefreshDb();

            Container.Install(new WindsorInstaller());

            WriteRepo = Container.Resolve<INEventStoreRepository<DataProvider>>();
            Handler = Container.Resolve<IHandleMessages>();
        }

        public override void Observe()
        {
            
        }

        protected void AssertRequestField(string name, RequestFieldType type)
        {
            var field = DataProvider.RequestFields.Get(name);
            field.ShouldNotBeNull();

            //todo: check type
            //field.Type.ShouldEqual(((int)type).ToString());
        }

        protected IDataField AssertDataField(string name, string definition, string label, double costOfSale, bool isSelected, int order, Type type, int industryCount = 0, int dataFieldCount = 0, IEnumerable<IDataField> dataFields = null)
        {
            dataFields = dataFields ?? DataProvider.DataFields;
            var field = dataFields.Get(name);
            field.Definition.ShouldEqual(definition);
            field.Label.ShouldEqual(label);
            field.CostOfSale.ShouldEqual(costOfSale);
            field.IsSelected.ShouldEqual(isSelected);
            field.Namespace.ShouldBeNull();
            field.Order.ShouldEqual(order);
            field.Type.ShouldEqual(type.ToString());
            field.Value.ShouldBeNull();
            field.Industries.Count().ShouldEqual(industryCount);
            field.DataFields.Count().ShouldEqual(dataFieldCount);
            return field;
        }
    }
}