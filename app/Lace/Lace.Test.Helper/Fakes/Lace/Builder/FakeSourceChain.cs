﻿using System;
using System.Collections.Generic;
using System.Linq;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceChain : IBuildSourceChain
    {
        private readonly IAmPackageForRequest _action;

        public FakeSourceChain(IAmPackageForRequest action)
        {
            _action = action;
        }

        public void Build()
        {
            if (string.IsNullOrEmpty(_action.Action))
            {
                throw new Exception("Action for request is empty");
            }


            SourceChain =
                new FakeSourceSpecification().Specifications.SingleOrDefault(
                    w => w.Key.Equals(_action.Action, StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        public Action<ICollection<IPointToLaceRequest>, NServiceBus.IBus, ICollection<IPointToLaceProvider>, Guid> SourceChain { get; private set; }


    }
}
