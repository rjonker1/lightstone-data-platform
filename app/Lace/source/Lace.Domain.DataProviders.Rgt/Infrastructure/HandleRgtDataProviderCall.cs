﻿using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Rgt.Infrastructure
{
    public class HandleRgtDataProviderCall  : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromRgtSource());
        }
    }
}