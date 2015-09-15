using System;
using System.Linq;
using DataPlatform.Shared.Enums;
using Nancy.Testing;
using PackageBuilder.Acceptance.Tests.Bases;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.TestObjects.Mothers;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Modules.DataProviders
{
    public class when_updating_the_pcubed_fica_data_provider : BaseDataProviderTest
    {
        public when_updating_the_pcubed_fica_data_provider()
        {
            Handler.Handle(new CreateDataProvider(Id, DataProviderName.PCubedFica, 0, "Owner", DateTime.UtcNow));

            Transaction(Session =>
            {
                Response = Browser.Put(RouteConstants.DataProviderEditRoute.Replace("{id}", Id.ToString()), with =>
                {
                    with.Header("Accept", "application/json");
                    with.JsonBody(DataProviderDtoMother.PCubedFica);
                });
            });

            DataProvider = WriteRepo.GetById(Id);
        }

        public override void Observe()
        {

        }

        [Observation]
        public void should_return_success_response()
        {
            Response.Body.AsString().ShouldNotBeNull();
            Response.Body.AsString().ShouldContain("Success");
        }

        [Observation]
        public void should_update_root_properties()
        {
            DataProvider.Name.ShouldEqual(DataProviderName.PCubedFica);
            DataProvider.Description.ShouldEqual("PCubedFica");
            DataProvider.CreatedDate.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.EditedDate.Value.Date.ShouldEqual(DateTime.UtcNow.Date);
            DataProvider.Owner.ShouldEqual("Owner");
            DataProvider.Version.ShouldEqual(2);
            DataProvider.CostOfSale.ShouldEqual(10);
        }

        [Observation]
        public void should_contain_all_request_fields()
        {
            DataProvider.RequestFields.Count().ShouldEqual(0);
        }

        [Observation]
        public void should_contain_all_data_fields()
        {
            DataProvider.DataFields.Count().ShouldEqual(8);
        }

        [Observation]
        public void should_update_data_field_transaction_token()
        {
            AssertDataField("TransactionToken", "TransactionToken Definition", "TransactionToken Label", 10, true, 0, typeof(Guid));
        }

        [Observation]
        public void should_update_data_field_id_number()
        {
            AssertDataField("IdNumber", "IdNumber Definition", "IdNumber Label", 10, true, 0, typeof(Int64));
        }

        [Observation]
        public void should_update_data_field_initials()
        {
            AssertDataField("Initials", "Initials Definition", "Initials Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_surname()
        {
            AssertDataField("Surname", "Surname Definition", "Surname Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_cell_number()
        {
            AssertDataField("CellNumber", "CellNumber Definition", "CellNumber Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_life_status()
        {
            AssertDataField("LifeStatus", "LifeStatus Definition", "LifeStatus Label", 10, true, 0, typeof(string));
        }

        [Observation]
        public void should_update_data_field_date_of_birth()
        {
            AssertDataField("DateOfBirth", "DateOfBirth Definition", "DateOfBirth Label", 10, true, 0, typeof(DateTime?));
        }

        [Observation]
        public void should_update_data_field_response_date()
        {
            AssertDataField("ResponseDate", "ResponseDate Definition", "ResponseDate Label", 10, true, 0, typeof(DateTime));
        }
    }
}