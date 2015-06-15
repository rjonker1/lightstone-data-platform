﻿using System;
using System.Collections.Generic;
using System.ServiceModel;
using Common.Logging;
using Lace.Domain.Core.Contracts.DataProviders.Business;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Management;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using DataSet = System.Data.DataSet;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure
{
    public class CallLightstoneBusinessCompanyDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private DataSet _result;

        public CallLightstoneBusinessCompanyDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
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
                    throw new Exception("Cannot continue calling Lightstone Business Api. User is not valid");

                var request = new CompanyRequest(_dataProvider.GetRequest<IAmLightstoneBusinessCompanyRequest>()).Map().Validate();
                if (!request.IsValid)
                    throw new Exception("Cannot continue call Lightstone Business Api. Request is not valid");

                var companiesDs = webService.Client.returnCompanies(webService.UserToken.ToString(), request.CompanyName, request.CompanyRegnum,
                    request.CompanyVatnumber);
                var company = Dto.Company.GetFromDataset(companiesDs);
                if (!company.Valid())
                    throw new Exception(string.Format("Company with Name {0} could not be found", request.CompanyName));

                var confirmation = webService.Client.confirmCompany(webService.UserToken.ToString(), company.CompanyId, Guid.NewGuid().ToString());
                var confirm = Confirmation.Get(confirmation);
                if (!confirm.Valid())
                    throw new Exception(string.Format("Company with Id {0} could not be confirmed", company.CompanyId));

                _result = webService.Client.returnCompanyReport(confirm.ReportGuid.ToString());

                TransformResponse(response);

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
            var lightstoneBusinessResponse = new LightstoneBusinessCompanyResponse();
            lightstoneBusinessResponse.HasBeenHandled();
            response.Add(lightstoneBusinessResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformLightstoneCompanyResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result ?? new LightstoneBusinessCompanyResponse(new List<IProvideCompany>()), null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}