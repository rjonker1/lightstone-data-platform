﻿using System;
using Lace.Source;
using Lace.Test.Helper.Builders.Sources;

namespace Lace.Test.Helper.Fakes.Lace.Handlers
{
    public class FakeHandleIvidServiceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromSourceBuilder().ForIvid());
        }
    }
}