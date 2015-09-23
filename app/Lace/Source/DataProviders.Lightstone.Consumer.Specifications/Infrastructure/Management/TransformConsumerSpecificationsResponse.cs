using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using Newtonsoft.Json;

namespace Lace.Domain.DataProviders.Lightstone.Consumer.Specifications.Infrastructure.Management
{
    public class TransformConsumerSpecificationsResponse : ITransform
    {
        private readonly string _jsonRepairHistory;

        public TransformConsumerSpecificationsResponse(string jsonRepairHistory, ICauseCriticalFailure critical)
        {
            _jsonRepairHistory = jsonRepairHistory;
            Continue = !string.IsNullOrEmpty(_jsonRepairHistory);
            Result = Continue
                ? null
                : critical.IsCritical()
                    ? LightstoneConsumerSpecificationsResponse.Failure(critical.Message)
                    : LightstoneConsumerSpecificationsResponse.Empty();
        }

        public void Transform()
        {
            var repairData = JsonConvert.DeserializeObject<RepairDataResponse[]>(_jsonRepairHistory);
            Result = new LightstoneConsumerSpecificationsResponse(repairData);
        }

        public bool Continue { get; private set; }
        public IProvideDataFromLightstoneConsumerSpecifications Result { get; private set; }
    }
}