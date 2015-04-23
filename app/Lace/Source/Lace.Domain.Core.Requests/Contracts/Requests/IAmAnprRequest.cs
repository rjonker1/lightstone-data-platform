﻿using Lace.Domain.Core.Requests.Contracts.RequestFields;

namespace Lace.Domain.Core.Requests.Contracts.Requests
{
    public interface IAmAnprRequest : IAmDataProviderRequest
    {
        IAmImageRequestField Image { get; }
    }
}