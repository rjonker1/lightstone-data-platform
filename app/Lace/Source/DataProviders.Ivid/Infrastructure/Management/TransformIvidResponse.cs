using System;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Common.Logging;
using DataPlatform.Shared.Enums;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Models;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Enums;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public sealed class TransformIvidResponse : ITransform
    {
        private static readonly ILog Log = LogManager.GetLogger<TransformIvidResponse>();
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

            Result.AddResponseState(DataProviderResponseState.Successful);

            AddToCache();
        }

        public void SetStatusMessages(HpiStandardQueryRequest request)
        {
            Result.AddReportStatusMessage((Result.HasIssues || Result.HasNoRecords)
                ? StatusMessageType.FurtherInvestigation.Description()
                : StatusMessageType.NoStatusFeedbackRequired.Description());

            Result.AddReportStatusMessage((!string.IsNullOrEmpty(request.LicenceNo) && !string.IsNullOrEmpty(Result.License) &&
                                           !Result.License.Equals(request.LicenceNo, StringComparison.CurrentCultureIgnoreCase))
                ? StatusMessageType.LicensePlateMismatch.Description()
                : StatusMessageType.NoStatusFeedbackRequired.Description());
        }

        private async void AddToCache()
        {
            if (Result.HasNoRecords)
                return;
            //Result.AddToCache(CacheDataRepository.ForCacheOnly());
            try
            {
                await Task.Run(() =>
                {
                    try
                    {
                        Result.AddToCache(CacheDataRepository.ForCacheOnly());
                    }
                    catch (Exception ex)
                    {
                        Log.ErrorFormat("Could not load ivid reaponse into cache because of {0}", ex, ex.Message);
                    }
                });
            }
            catch
            {
            }
        }

        private static IvidCodePair BuildIvidCodePair(CodeDescription description)
        {
            return description == null
                ? new IvidCodePair(string.Empty, string.Empty)
                : new IvidCodePair(description.code, description.description);
        }

       

        public HpiStandardQueryResponse Message { get; private set; }
        public IvidResponse Result { get; private set; }
        public bool Continue { get; private set; }
    }
}
