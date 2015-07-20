using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using PackageBuilder.Api.Installers;
using PackageBuilder.Core.MessageHandling;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Domain.CommandHandlers.DataProviders;
using PackageBuilder.Domain.CommandHandlers.DataProviders.Responses;
using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.Contracts.DataFields.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.TestHelper.BaseTests;
using Xunit.Extensions;

namespace PackageBuilder.Acceptance.Tests.Handlers.CommandHandlers
{
    public class VehicleData
    {
        public int VehicleId { get; set; }
    }

    public class AmendedIvidDataProvider : IPointToLaceProvider
    {
        public void HasNotBeenHandled()
        {
            throw new NotImplementedException();
        }

        public void HasBeenHandled()
        {
            throw new NotImplementedException();
        }

        public bool Handled { get; private set; }
        public Type Type { get; private set; }
        public string TypeName { get; private set; }
        public string MakeCode { get; private set; }
        public string MakeDescription { get; private set; }
        public string ModelCode { get; private set; }
        public string ModelDescription { get; private set; }
        public string ColourCode { get; private set; }
        public string ColourDescription { get; private set; }
        public string DrivenCode { get; private set; }
        public string DrivenDescription { get; private set; }
        public string CategoryCode { get; private set; }
        public string CategoryDescription { get; private set; }
        public string DescriptionCode { get; private set; }
        public string Description { get; private set; }
        public string EconomicSectorCode { get; private set; }
        public string EconomicSectorDescription { get; private set; }
        public string LifeStatusCode { get; private set; }
        public string LifeStatusDescription { get; private set; }
        public string SapMarkCode { get; private set; }
        public string SapMarkDescription { get; private set; }
        public bool HasIssues { get; private set; }
        public bool HasErrors { get; private set; }
        public string CarFullname { get; private set; }
        public VehicleData VehicleData { get; private set; }

        public AmendedIvidDataProvider()
        {
            VehicleData = new VehicleData();
        }
    }

    public class when_amending_data_provider_structure : when_persisting_entities_to_db
    {
        private readonly Guid _id = Guid.NewGuid();
        private IEnumerable<IDataField> _originalFields;
        private IEnumerable<IDataField> _newFields;
        private readonly IHandleMessages _handler;
        private readonly IHandleMessages _amendHandler;
        private readonly INEventStoreRepository<DataProvider> _writeRepo;
        private struct DataProviderResponseRepository : IAmDataProviderResponseRepository
        {
            public IPointToLaceProvider GetDataProvider(DataProviderName name)
            {
                return new AmendedIvidDataProvider();
            }
        }

        public when_amending_data_provider_structure()
        {
            base.Observe();

            Container.Install(
                new WindsorInstaller(), 
                new RepositoryInstaller(),
                new CommandInstaller(),
                new BusInstaller(),
                new NEventStoreInstaller(),
                new ServiceLocatorInstaller(),
                new AutoMapperInstaller(),
                new LaceInstaller(),
                new AuthInstaller(),
                new ApiInstaller()
                );

            _handler = Container.Resolve<IHandleMessages>();
            _writeRepo = Container.Resolve<INEventStoreRepository<DataProvider>>();
            _amendHandler = new AmendDataProviderStructureHandler(_writeRepo, new DataProviderResponseRepository());

            Mapper.CreateMap<AmendedIvidDataProvider, IEnumerable<IDataField>>()
                .ConvertUsing(Mapper.Map<object, IEnumerable<DataField>>);
            Mapper.CreateMap<VehicleData, DataField>()
                .ForMember(d => d.Name, opt => opt.MapFrom(x => "VehicleData"))
                .ForMember(d => d.Type, opt => opt.MapFrom(x => x.GetType()))
                .ForMember(d => d.DataFields, opt => opt.MapFrom(x => Mapper.Map<object, IEnumerable<DataField>>(x)));
        }

        public override void Observe()
        {
            base.Observe();

            _handler.Handle(new CreateDataProvider(_id, DataProviderName.Ivid, 0, "", DateTime.UtcNow));

            _originalFields = _writeRepo.GetById(_id).DataFields.ToList();
            var field = _originalFields.Filter(x => x.Name == "MakeDescription").FirstOrDefault() as DataField;
            field.Label = "Test Label";

            _handler.Handle(new UpdateDataProvider(_id, DataProviderName.Ivid, "Test", 0, null, false, null, 2, "Owner", DateTime.UtcNow, null, null, _originalFields));

            _amendHandler.Handle(new AmendDataProviderStructure(_id));

            _newFields = _writeRepo.GetById(_id).DataFields.ToList();
        }

        [Observation]
        public void should_amend_dataField_structure_based_on_new_dataProvider_response_object()
        {
            _originalFields.Count().ShouldEqual(32);
            _newFields.Count().ShouldEqual(22);
        }

        [Observation]
        public void should_retain_original_values_from_prior_dataField_structure()
        {
            var field = _newFields.Filter(x => x.Name == "MakeDescription").FirstOrDefault();
            field.Label.ShouldEqual("Test Label");
        }
    }
}