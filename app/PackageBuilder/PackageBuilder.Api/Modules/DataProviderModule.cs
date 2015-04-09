using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
using PackageBuilder.Domain.Entities.Enums.DataProviders;
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.Infrastructure.Repositories;
using Shared.BuildingBlocks.Api.Security;
using DataProviderDto = PackageBuilder.Domain.Dtos.Read.DataProviderDto;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : SecureModule
    {
        private static int _defaultJsonMaxLength;

        public DataProviderModule(IPublishStorableCommands publisher,
            IDataProviderRepository readRepo,
            INEventStoreRepository<DataProvider> writeRepo, IRepository<State> stateRepo)
        {
            if (_defaultJsonMaxLength == 0)
                _defaultJsonMaxLength = JsonSettings.MaxJsonLength;

            //Hackeroonie - Required, due to complex model structures (Nancy default restriction length [102400])
            JsonSettings.MaxJsonLength = Int32.MaxValue;

            Get["/DataProviders"] = parameters => {
                var test = Response.AsJson(Mapper.Map<IEnumerable<Domain.Entities.DataProviders.Read.DataProvider>, IEnumerable<DataProviderDto>>(readRepo));
                return test;
            };

            Get["/DataProviders/Latest"] = parameters =>
            {
                var dataSources = readRepo.GetUniqueIds().Select(x => Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(x))).ToList();
                return Response.AsJson(dataSources);
            };

            Get["/DataProviders/{id}"] = parameters => 
                Response.AsJson(new { Response = new []{ Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(parameters.id)) } });

            Get["/DataProviders/{id}/{version}"] = parameters =>
                Response.AsJson(new { Response = new[] { Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(parameters.id, parameters.version)) } });

            Put["/Dataproviders/{id}"] = parameters =>
            {
                var dto = this.Bind<Domain.Dtos.Write.DataProviderDto>("Industries");
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(dto.DataFields);
                var command = new UpdateDataProvider(parameters.id,
                    (DataProviderName) Enum.Parse(typeof (DataProviderName), dto.Name, true), dto.Description,
                    dto.CostOfSale, typeof (Domain.Dtos.Write.DataProviderDto), dto.FieldLevelCostPriceOverride,
                    stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.UtcNow, dFields);
                publisher.Publish(command);

                return Response.AsJson(new {msg = "Success, " + parameters.id + " created"});
            };

            Post["DataProvider/Clone/{id}/{cloneName}"] = ParametersBackTrackExtensions =>
            {
                return Response.AsJson(new {msg = "Works"});
            };
        }
    }
}