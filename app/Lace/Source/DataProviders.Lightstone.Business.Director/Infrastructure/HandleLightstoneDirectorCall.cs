﻿using System;
using Lace.Domain.DataProviders.Core.Contracts;

namespace Lace.Domain.DataProviders.Lightstone.Business.Director.Infrastructure
{
    public sealed class HandleLightstoneDirectorCall : IHandleDataProviderSourceCall
    {
        public void Request(Action<IRequestDataFromDataProviderSource> action)
        {
            action(new RequestDataFromLightstoneDirector());
        }
    }
}
