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
                //if (webService.Client.State == CommunicationState.Closed)
                //    webService.Client.Open();

                if (webService.UserToken == Guid.Empty)
                    throw new Exception("Cannot continue calling Lightstone Business Api. User is not valid");

                var request = new CompanyRequest(_dataProvider.GetRequest<IAmLightstoneBusinessCompanyRequest>()).Map().Validate();
                if (!request.IsValid)
                    throw new Exception("Cannot continue call Lightstone Business Api. Request is not valid");

                //var companiesDs = webService.Client.returnCompanies(webService.UserToken.ToString(), request.CompanyName, request.CompanyRegnum,
                //    request.CompanyVatnumber);
                //var company = Dto.Company.GetFromDataset(companiesDs);
                //if (!company.Valid())
                //    throw new Exception(string.Format("Company with Name {0} could not be found", request.CompanyName));

                //var confirmation = webService.Client.confirmCompany(webService.UserToken.ToString(), company.CompanyId, Guid.NewGuid().ToString());
                //var confirm = Confirmation.Get(confirmation);
                //if (!confirm.Valid())
                //    throw new Exception(string.Format("Company with Id {0} could not be confirmed", company.CompanyId));

                //_result = webService.Client.returnCompanyReport(confirm.ReportGuid.ToString());

                TransformResponse(response);

                ////Director Search
                ////get directors
                ////var idNumber = _dataProvider.GetRequest<IAmLightstoneBusinessRequest>().IdNumber;
                //const string idNumber = "7902065199085";
                //const string firstname = "MURRAY GRANT";
                //const string surname = "WOOLFSON";
                //var directorDs = webService.Client.returnDirectors(webService.UserToken.ToString(), null, null, idNumber);

                //var director = Director.GetFromDataset(directorDs);
                //if(!director.Valid())
                //    throw new Exception(string.Format("Director with Id Number {0} is not valid", idNumber));

                ////confirm director
                //var confirmReport = webService.Client.confirmDirector(webService.UserToken.ToString(), director.DirectorId, director.IdNumber.ToString(),
                //    Guid.NewGuid().ToString());

                //var confirm = ConfirmDirector.Get(confirmReport);
                //if(!confirm.Valid())
                //    throw new Exception(string.Format("Director with Id {0} could not be confirmed", director.DirectorId));



                // authenticate
                // call authenticateUser to get the UserToke by email and password
                // email: murray@lightstone.co.za
                //pass: Pass!1234

            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling Lightstone Business Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new {ErrorMessage = "Error calling Lightstone Business Data Provider"});
                LightstoneBusinessResponseFailed(response);
            }
        }

        private static void LightstoneBusinessResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var lightstoneBusinessResponse = new LightstoneBusinessDirectorResponse();
            lightstoneBusinessResponse.HasBeenHandled();
            response.Add(lightstoneBusinessResponse);
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