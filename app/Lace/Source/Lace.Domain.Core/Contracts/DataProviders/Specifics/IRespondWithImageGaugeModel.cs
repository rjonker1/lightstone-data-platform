using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithImageGaugeModel : IProvideType
    {
        double? MinValue { get; }
        double? MaxValue { get; }
        double? Value { get; }
        double? Quarter { get; }
        string GaugeName { get; }
    }
}