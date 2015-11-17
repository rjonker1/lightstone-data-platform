using System;
using DataPlatform.Shared.Enums;

namespace Lace.Domain.Core.Requests.Contracts
{
    public interface IHaveRequestContext
    {
        Guid RequestId { get; }
        SystemType System { get; }
    }
}
