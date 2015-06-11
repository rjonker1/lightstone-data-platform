using System;
using System.Collections.Generic;
using System.Data;
using System.ServiceModel;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Property.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace Lace.Domain.DataProviders.Lightstone.Property.Infrastructure
{
    public class CallLightstonePropertyDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
      
        private DataSet _result;

        public CallLightstonePropertyDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var webService = new ConfigureSource();
                if (webService.Client.State == CommunicationState.Closed)
                    webService.Client.Open();

                var request = new GetPropertyRequest(_dataProvider.GetRequest<IAmLightstonePropertyRequest>())
                    .Map()
                    .Validate();

                _logCommand.LogConfiguration(new { request },null);

                if (!request.IsValid)
                    throw new Exception(
                        string.Format(
                            "Minimum requirements for Lightstone Property request has not been met with User id {0} and  Id or CK {1} and Max Rows to Return {2} and Tracking Number {3}",
                            request.UserId, request.IdCkOfOwner, request.MaxRowsToReturn, request.TrackingNumber));

                _logCommand.LogRequest(new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString()).ForWebApiType(), new { request });

                _result = webService.Client.ReturnProperties(request.UserId, request.Province, request.Municipality,
                    request.DeedTown,
                    request.ErfNumber, request.Portion, request.SectionalTitle, request.Unit, request.Suburb,
                    request.Street,
                    request.StreetNumber, request.OwnerName, request.IdCkOfOwner, request.EstateName, request.FarmName,
                    request.MaxRowsToReturn, request.TrackingNumber);

                webService.CloseSource();

                _logCommand.LogResponse(_result != null ? DataProviderState.Successful : DataProviderState.Failed,new ConnectionTypeIdentifier(webService.Client.Endpoint.Address.ToString())
                        .ForWebApiType(), new {_result});

           
                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Property Data Provider {0}", ex,ex.Message);
                _logCommand.LogFault(new { ex}, new {ErrorMessage = "Error calling Lightstone Property Data Provider"});
                LightstonePropertyResponseFailed(response);
            }
        }

        private static void LightstonePropertyResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstonePropertyResponse = new LightstonePropertyResponse();
            lightstonePropertyResponse.HasBeenHandled();
            response.Add(lightstonePropertyResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstonePropertyResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }
            _logCommand.LogTransformation(transformer.Result ?? new LightstonePropertyResponse(new List<PropertyModel>()), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
