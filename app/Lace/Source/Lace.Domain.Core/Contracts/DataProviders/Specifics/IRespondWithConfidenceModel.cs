using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithConfidenceModel : IProvideType
    {
        string CarType { get; }
        int Year { get; }
        double Value { get; }
    }
}
