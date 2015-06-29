using System;
using System.Threading.Tasks;
using Lace.Caching.BuildingBlocks.Repository;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Models;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Ivid.IvidServiceReference;

namespace Lace.Domain.DataProviders.Ivid.Infrastructure.Management
{
    public class TransformIvidResponse : ITransformResponseFromDataProvider
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

            //Result.AddToCache(CacheDataRepository.ForCacheOnly());
            AddToCache();
        }

        public void SetReportStatus(HpiStandardQueryRequest request)
        {
            RuleProcessor.ForReportStatusMessage(request, Result);
        }

        private void AddToCache()
        {
            if(!Result.HasNoRecords)
                return;

            try
            {
                Task.Run(() => Result.AddToCache(CacheDataRepository.ForCacheOnly()));
            }
            catch (Exception ex)
            {

            }
        }

        private static IvidCodePair BuildIvidCodePair(CodeDescription description)
        {
            return description == null
                ? new IvidCodePair(string.Empty, string.Empty)
                : new IvidCodePair(description.code, description.description);
        }
    }
}
