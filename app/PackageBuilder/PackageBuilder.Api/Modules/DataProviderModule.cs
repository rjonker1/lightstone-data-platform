using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
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
using PackageBuilder.Domain.Entities.States.Read;
using PackageBuilder.Infrastructure.Repositories;
using AudatexResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.AudatexResponse;
using DataProviderDto = PackageBuilder.Domain.Dtos.Read.DataProviderDto;
using IvidResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.IvidResponse;
using LightstoneAutoResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.LightstoneAutoResponse;
using LightstonePropertyResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.LightstonePropertyResponse;
using SignioDriversLicenseDecryptionResponse = PackageBuilder.Domain.CommandHandlers.DataProviders.Responses.SignioDriversLicenseDecryptionResponse;

namespace PackageBuilder.Api.Modules
{
    public class DataProviderModule : NancyModule// : SecureModule
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

            Get["/DataProviders/{id}"] = parameters => 
                Response.AsJson(new { Response = new []{ Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(parameters.id)) } });

            Get["/DataProviders/{id}/{version}"] = parameters =>
                Response.AsJson(new { Response = new[] { Mapper.Map<IDataProvider, Domain.Dtos.Write.DataProviderDto>(writeRepo.GetById(parameters.id, parameters.version)) } });

            Put["/Dataproviders/{id}"] = parameters =>
            {
                var dto = this.Bind<Domain.Dtos.Write.DataProviderDto>("Industries");
                var dFields = Mapper.Map<IEnumerable<DataProviderFieldItemDto>, IEnumerable<DataField>>(dto.DataFields);
                //var command = new UpdateDataProvider(parameters.id,
                //    (DataProviderName) Enum.Parse(typeof (DataProviderName), dto.Name, true), dto.Description,
                //    dto.CostOfSale, typeof (Domain.Dtos.Write.DataProviderDto), dto.FieldLevelCostPriceOverride,
                //    stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.UtcNow, dFields);

                var command = new UpdateDataProvider(parameters.id,
                    (DataProviderName)Enum.Parse(typeof(DataProviderName), dto.Name, true), dto.Description,
                    dto.CostOfSale, typeof(Domain.Dtos.Write.DataProviderDto), dto.FieldLevelCostPriceOverride,
                    stateRepo.FirstOrDefault(), dto.Version, dto.Owner, dto.CreatedDate, DateTime.UtcNow, CheckDataProviderResponse(dto.Name));
                publisher.Publish(command);

                return Response.AsJson(new {msg = "Success, " + parameters.id + " created"});
            };

            Post["DataProvider/Clone/{id}/{cloneName}"] = ParametersBackTrackExtensions =>
            {
                return Response.AsJson(new {msg = "Works"});
            };
        }

        private IPointToLaceProvider CheckDataProviderResponse(string dataProviderName)
        {
            switch ((DataProviderName)Enum.Parse(typeof(DataProviderName), dataProviderName, true))
            {
                case DataProviderName.Ivid:
                    return new IvidResponse().DefaultIvidResponse();
                case DataProviderName.IvidTitleHolder:
                    return new IvidTitleHolderResponse();
                case DataProviderName.Rgt:
                    return new RgtResponse();
                case DataProviderName.RgtVin:
                    return new RgtVinResponse();
                case DataProviderName.LightstoneAuto:
                    return new LightstoneAutoResponse().DefaultLightstoneResponse();
                case DataProviderName.Audatex:
                    return new AudatexResponse().DefaultAudatexResponse();
                case DataProviderName.Jis:
                    return new JisResponse();
                case DataProviderName.Anpr:
                    return new AnprResponse();
                case DataProviderName.PCubedFica:
                    return new PCubedFicaVerficationResponse();
                case DataProviderName.SignioDecryptDriversLicense:
                    return new SignioDriversLicenseDecryptionResponse().DefaultSignioDriversLicenseDecryptionResponse();
                case DataProviderName.LightstoneProperty:
                    return new LightstonePropertyResponse().DefaultLightstonePropertyResponse();
                case DataProviderName.LightstoneBusiness:
                    return new LightstoneBusinessResponse();
                default:
                    return null;
            }
        }
    }
}