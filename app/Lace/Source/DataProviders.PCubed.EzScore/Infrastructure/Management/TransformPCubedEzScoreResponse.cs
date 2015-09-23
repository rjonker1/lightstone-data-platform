using System.Collections.Generic;
using System.Net;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.DataProviders.Consumer;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Lace.Toolbox.PCubed.Domain;
using RestSharp;

namespace Lace.Domain.DataProviders.PCubed.EzScore.Infrastructure.Management
{
    public class TransformPCubedEzScoreResponse : ITransform
    {
        private readonly ConsumerViewResponse _response;

        public TransformPCubedEzScoreResponse(IRestResponse<ConsumerViewResponse> response, ICauseCriticalFailure critical)
        {
            Continue = response != null && response.Data != null && response.Data.ResponseStatusCode == HttpStatusCode.OK;
            Result = Continue ? null : critical.IsCritical() ? PCubedEzScoreResponse.Failure(critical.Message) : PCubedEzScoreResponse.Empty();
            _response = Continue ? response.Data : new ConsumerViewResponse();
        }


        public void Transform()
        {

            if (_response == null || _response.IndividualData == null || _response.IndividualData.Individuals == null)
            {
                Result = PCubedEzScoreResponse.Empty();
                return;
            }

            Result =  PCubedEzScoreResponse.WithRecords(GetConsumerViewRecords());
        }

        private IEnumerable<IRespondWithEzScore> GetConsumerViewRecords()
        {
            foreach (var individual in _response.IndividualData.Individuals.Individual)
            {
                yield return GetDetail(individual.PCubed.Detail, GetHeader(individual.PCubed.Header));
            }
        }

        private static EzScoreRecord GetHeader(Header header)
        {
            var record = new EzScoreRecord();
            return header == null ? record : record.WithHeader(header.Phone1, header.Phone2, header.Phone3, header.EmailAddress1, header.EmailAddress2,
                header.EmailAddress3, header.Surname, header.FirstName, header.IDNumber);
        }

        private static IRespondWithEzScore GetDetail(Detail detail, EzScoreRecord record)
        {
            return detail == null
                ? record
                : record.WithDetail(detail.DemLSM, detail.FASNonCPAGroupDescriptionShort, detail.MosaicCPAGroupMerged, detail.WealthIndex,
                    detail.CreditGradeNonCPA, detail.DemHomeOwner, detail.DemDeceased,
                    detail.DemPredictedRace, detail.DemGender, detail.PostalAddressPostCode, detail.PostalAddressProvince,
                    detail.PostalAddressTownCity, detail.PostalAddressSuburb, detail.PostalAddressLine2, detail.PostalAddressLine1,
                    detail.AddressPostCode, detail.AddressProvince, detail.AddressTownCity, detail.AddressSuburb, detail.AddressLine2,
                    detail.AddressLine1, detail.ExtractDate);
        }

       

        public bool Continue { get; private set; }
        public IProvideDataFromPCubedEzScore Result { get; private set; }
    }
}
