using System;
using System.ServiceModel;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Configuration;
using Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Dto;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure.Management
{
    public sealed class DirectorDataRetriever
    {
        private readonly ConfigureApi _api;
        private readonly DirectorRequest _request;

        private Dto.Director _director;
        private Confirmation _confirmation;

        private DirectorDataRetriever(ConfigureApi api, DirectorRequest request)
        {
            _api = api;
            _request = request;
        }

        public static DirectorDataRetriever Start(ConfigureApi api, DirectorRequest request)
        {
            return new DirectorDataRetriever(api, request);
        }

        public DirectorDataRetriever WithReturnDirectors()
        {
            if (_api.Client.State == CommunicationState.Closed)
                _api.Client.Open();

            var directorDs = _api.Client.returnDirectors(_api.UserToken.ToString(), _request.FirstName, _request.FirstName, _request.IdNumber);
            _director = Dto.Director.GetFromDataset(directorDs);
            if (!_director.Valid())
                throw new Exception(string.Format("Director with Id Number {0} is not valid", _request.IdNumber));
            return this;
        }

        public DirectorDataRetriever ThenConfirmDirector()
        {
            if (_api.Client.State == CommunicationState.Closed)
                _api.Client.Open();

            var confirmReport = _api.Client.confirmDirector(_api.UserToken.ToString(), _director.DirectorId, _director.IdNumber.ToString(),
                Guid.NewGuid().ToString());

            _confirmation = Confirmation.Get(confirmReport);
            if (!_confirmation.Valid())
                throw new Exception(string.Format("Director with Id {0} could not be confirmed", _director.DirectorId));

            return this;
        }

        public void FinallyGetDirectorReport(out System.Data.DataSet report)
        {
            report = _api.Client.returnDirectorReport(_confirmation.ReportGuid.ToString());
        }
    }
}
