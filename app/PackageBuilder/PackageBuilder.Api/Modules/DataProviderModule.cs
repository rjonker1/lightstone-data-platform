using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Nancy;
using Nancy.Json;
using Nancy.ModelBinding;
using PackageBuilder.Api.Helpers.Constants;
using PackageBuilder.Core.NEventStore;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers;
using PackageBuilder.Domain.Dtos.Write;
using PackageBuilder.Domain.Entities.Contracts.DataProviders.Write;
using PackageBuilder.Domain.Entities.DataFields.Write;
using PackageBuilder.Domain.Entities.DataProviders.Commands;
using PackageBuilder.Domain.Entities.DataProviders.Write;
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

            Get["/DataProviders"] = _ => {
                var test = Response.AsJson(Mapper.Map<IEnumerable<Domain.Entities.DataProviders.Read.DataProvider>, IEnumerable<DataProviderDto>>(readRepo));
                return test;
            };

            Get["/DataProviders/Latest"] = _ =>
            {
                var repoSource =
                    readRepo.GetUniqueIds()
                        .Select(x => Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(x)))
                        .ToList();

                var dataSources = new List<Domain.Dtos.Write.DataProviderDto>();
                //var requestFields = new List<DataProviderFieldItemDto>();

                foreach (var entity in repoSource)
                {
                    var requestFields = entity.RequestFields.Where(requestField => requestField != null);
                    dataSources.Add(new Domain.Dtos.Write.DataProviderDto
                    {
                        Id = entity.Id,
                        Name = entity.Name,
                        Description = entity.Description,
                        CostOfSale = entity.CostOfSale,
                        SourceConfigurationIsApiConfiguration = entity.SourceConfigurationIsApiConfiguration,
                        SourceConfigurationUrl = entity.SourceConfigurationUrl,
                        SourceConfigurationUsername = entity.SourceConfigurationUsername,
                        SourceConfigurationConnectionString = entity.SourceConfigurationConnectionString,
                        FieldLevelCostPriceOverride = entity.FieldLevelCostPriceOverride, 
                        Owner = entity.Owner,
                        CreatedDate = entity.CreatedDate,
                        EditedDate = entity.EditedDate, 
                        RequestFields = requestFields,
                        DataFields = entity.DataFields
                    });
                }

                return Response.AsJson(dataSources);
            };

            Get["/DataProviders/{id}"] = _ => 
                Response.AsJson(new { Response = new []{ Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(_.id)) } });

            Get["/DataProviders/{id}/{version}"] = _ =>
                Response.AsJson(new { Response = new[] { Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(_.id, _.version)) } });

            Put[RouteConstants.DataProviderEditRoute] = _ =>
            {
                var dto = this.Bind<Domain.Dtos.Write.DataProviderDto>();
                var rFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(dto.RequestFields);
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(dto.DataFields);
                //var command = new UpdateDataProvider(parameters.id,
                //    (DataProviderName) Enum.Parse(typeof (DataProviderName), dto.Name, true), dto.Description,
                //    dto.CostOfSale, typeof (Domain.Dtos.Write.DataProviderDto), dto.FieldLevelCostPriceOverride,
                //    stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.UtcNow, dFields);

                var command = new UpdateDataProvider(_.id,
                    (DataProviderName)Enum.Parse(typeof(DataProviderName), dto.Name, true), dto.Description,
                    dto.CostOfSale, typeof(Domain.Dtos.Write.DataProviderDto), dto.FieldLevelCostPriceOverride,
                    stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.UtcNow, rFields, dFields);
                publisher.Publish(command);

                return Response.AsJson(new {msg = "Success, " + _.id + " created"});
            };

            Put["/Dataproviders/{id}/amend"] = _ =>
            {
                var id = (Guid) _.id;
                publisher.Publish(new AmendDataProviderStructure(id));
                return Response.AsJson(new { msg = "Amended" });
            };

            Post["DataProvider/Clone/{id}/{cloneName}"] = ParametersBackTrackExtensions =>
            {
                return Response.AsJson(new {msg = "Works"});
            };
        }
    }
}