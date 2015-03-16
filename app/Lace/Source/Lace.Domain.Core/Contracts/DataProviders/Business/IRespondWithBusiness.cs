using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Business
{
    public interface IRespondWithBusiness : IProvideType
    {
        string Result { get; }
    }
}