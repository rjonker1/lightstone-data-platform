using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.DataProviders.Core.Contracts;
using Newtonsoft.Json;

namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Management
{
    public class TransformConsumerSpecificationsResponse : ITransform
    {
        private readonly string _jsonRepairHistory;

        public TransformConsumerSpecificationsResponse(string jsonRepairHistory)
        {
            _jsonRepairHistory = jsonRepairHistory;
            Continue = !string.IsNullOrEmpty(_jsonRepairHistory);
            Result = Continue ? null : LightstoneConsumerSpecificationsResponse.Empty();
        }

        public void Transform()
        {
            var repairData = JsonConvert.DeserializeObject<RepairDataResponse[]>(_jsonRepairHistory);
            Result = new LightstoneConsumerSpecificationsResponse(repairData);
            Result.AddResponseState(Result.RepairData.Any() ? DataProviderResponseState.Successful : DataProviderResponseState.NoRecords);
        }

        public bool Continue { get; private set; }
        public IProvideDataFromLightstoneConsumerSpecifications Result { get; private set; }
    }
}