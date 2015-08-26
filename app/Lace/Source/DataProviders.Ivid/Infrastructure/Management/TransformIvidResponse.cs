using System;
using System.Linq;
using System.Threading.Tasks;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Models;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public sealed class TransformIvidResponse : ITransformResponseFromDataProvider
    {
        public HpiStandardQueryResponse Message { get; private set; }
        public IvidResponse Result { get; private set; }

        public bool Continue { get; private set; }

        public TransformIvidResponse(HpiStandardQueryResponse response)
        {
            Continue = response != null;
            Result = Continue ? null : IvidResponse.Empty();
            Message = response;
        }

        public void Transform()
        {
            Result = IvidResponse.Build(Message.ividQueryResult.ToString(), Message.IvidReference, Message.licenceNumber,
                Message.registerNumber, Message.registrationDate, Message.vin, Message.engineNumber,
                Message.engineDisplacement, Message.tare);

            Result.SetErrorFlag(Message.partialResponse);

            Result.SetMake(BuildIvidCodePair(Message.make));

            Result.SetModel(BuildIvidCodePair(Message.model));

            Result.SetColor(BuildIvidCodePair(Message.colour));

            Result.SetDriven(BuildIvidCodePair(Message.driven));

            Result.SetCategory(BuildIvidCodePair(Message.category));

            Result.SetDescription(BuildIvidCodePair(Message.description));

            Result.SetEconomicSector(BuildIvidCodePair(Message.economicSector));

            Result.SetLifeStatus(BuildIvidCodePair(Message.lifeStatus));

            Result.SetSapMark(BuildIvidCodePair(Message.sapMark));
            Result.SetHasIssuesFlag(Message.ividQueryResult == IvidQueryResult.FURTHER_INVESTIGATION);
            Result.SetHasNoRecordsFlag(Message.ividQueryResult == IvidQueryResult.NO_RECORDS);

            Result.BuildSpecificInformation();

            Result.SetCarFullName();
            
            AddToCache();
        }

        public void SetStatusMessages(HpiStandardQueryRequest request)
        {
            Result.AddReportStatusMessage(
                DataChecks.ReportStatusMessages.FirstOrDefault(
                    w => w.Key == DataChecks.ResponseChecks((Result.HasIssues || Result.HasNoRecords), DataChecks.ValidationTest.FurtherInvestigation))
                    .Value);
            Result.AddReportStatusMessage(
                DataChecks.ReportStatusMessages.FirstOrDefault(
                    w => w.Key == DataChecks.ResponseChecks((!string.IsNullOrEmpty(request.LicenceNo) && !string.IsNullOrEmpty(Result.License) &&
                                                             !Result.License.Equals(request.LicenceNo, StringComparison.CurrentCultureIgnoreCase)),
                        DataChecks.ValidationTest.LicensePlateMismatch)).Value);

        }

        private void AddToCache()
        {
            if(Result.HasNoRecords)
                return;
            //Result.AddToCache(CacheDataRepository.ForCacheOnly());
            try
            {
                Task.Run(() => Result.AddToCache(CacheDataRepository.ForCacheOnly()));
            }
            catch {}
        }

        private static IvidCodePair BuildIvidCodePair(CodeDescription description)
        {
            return description == null
                ? new IvidCodePair(string.Empty, string.Empty)
                : new IvidCodePair(description.code, description.description);
        }
    }
}
