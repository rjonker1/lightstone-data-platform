using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithAmortisedValueModel : IProvideType
    {
        string Year { get; }
        decimal Value { get; }
    }
}
