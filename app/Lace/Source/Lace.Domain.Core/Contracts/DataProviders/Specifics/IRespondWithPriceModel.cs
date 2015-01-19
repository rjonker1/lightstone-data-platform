using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Specifics
{
    public interface IRespondWithPriceModel : IProvideType
    {
        string Name { get; }
        decimal Value { get; }
    }
}