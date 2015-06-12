using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure
{
    public class CallLightstoneBusinessDirectorDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private DataSet _result;

        public CallLightstoneBusinessDirectorDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
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

                if (webService.UserToken == Guid.Empty)
                    throw new Exception("Cannot continue calling Lightstone Business Directory Api. User is not valid");

                var request = new DirectorRequest(_dataProvider.GetRequest<IAmLightstoneBusinessDirectorRequest>()).Map().Validate();
                if (!request.IsValid)
                    throw new Exception("Cannot continue call Lightstone Business Director Api. Request is not valid");

                var directorDs = webService.Client.returnDirectors(webService.UserToken.ToString(), request.FirstName, request.FirstName, request.IdNumber);
                var director = Dto.Director.GetFromDataset(directorDs);
                if (!director.Valid())
                    throw new Exception(string.Format("Director with Id Number {0} is not valid", request.IdNumber));

                var confirmReport = webService.Client.confirmDirector(webService.UserToken.ToString(), director.DirectorId, director.IdNumber.ToString(),
                    Guid.NewGuid().ToString());

                var confirm = Confirmation.Get(confirmReport);
                if (!confirm.Valid())
                    throw new Exception(string.Format("Director with Id {0} could not be confirmed", director.DirectorId));

                _result = webService.Client.returnDirectorReport(confirm.ReportGuid.ToString());

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Director Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Business Director Data Provider"});
                LightstoneDirectorResponseFailed(response);
            }
        }

        private static void LightstoneDirectorResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneDirectorResponse = new LightstoneBusinessDirectorResponse();
            lightstoneDirectorResponse.HasBeenHandled();
            response.Add(lightstoneDirectorResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneDirectorResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result ?? new LightstoneBusinessDirectorResponse(new List<IProvideDirector>()), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}