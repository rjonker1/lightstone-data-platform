﻿using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.RgtVin.Infrastructure
{
    public class HandleRgtVinDataProviderCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromRgtVinSource());
        }
    }
}