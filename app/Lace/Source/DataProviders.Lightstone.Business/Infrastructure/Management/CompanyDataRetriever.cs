using System;
using System.ServiceModel;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Management
{
    public sealed class CompanyDataRetriever
    {
        private readonly ConfigureApi _api;
        private readonly CompanyRequest _request;

        private Dto.Company _company;
        private Confirmation _confirmation;

        private CompanyDataRetriever(ConfigureApi api, CompanyRequest request)
        {
            _api = api;
            _request = request;
        }

        public static CompanyDataRetriever Start(ConfigureApi api, CompanyRequest request)
        {
            return new CompanyDataRetriever(api, request);
        }

        public CompanyDataRetriever WithReturnCompanies()
        {
            if (_api.Client.State == CommunicationState.Closed)
                _api.Client.Open();

            var companiesDs = _api.Client.returnCompanies(_api.UserToken.ToString(), _request.CompanyName, _request.CompanyRegnum,
                _request.CompanyVatnumber);
            _company = Dto.Company.GetFromDataset(companiesDs);
            if (!_company.Valid())
                throw new Exception(string.Format("Company with Name {0} could not be found", _request.CompanyName));
            return this;
        }

        public CompanyDataRetriever ThenConfirmCompany()
        {
            if (_api.Client.State == CommunicationState.Closed)
                _api.Client.Open();

            var confirmation = _api.Client.confirmCompany(_api.UserToken.ToString(), _company.CompanyId, Guid.NewGuid().ToString());
            _confirmation = Confirmation.Get(confirmation);
            if (!_confirmation.Valid())
                throw new Exception(string.Format("Company with Id {0} could not be confirmed", _company.CompanyId));

            return this;
        }

        public void FinallyGetCompanyReport(out System.Data.DataSet report)
        {
            report = _api.Client.returnCompanyReport(_confirmation.ReportGuid.ToString());
        }

    }
}