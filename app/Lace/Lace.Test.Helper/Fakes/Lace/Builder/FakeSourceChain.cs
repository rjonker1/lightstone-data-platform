﻿using System;
using System.Linq;
using Lace.Domain.Core.Contracts;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.Infrastructure.Core.Contracts;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using PackageBuilder.Domain.Entities;

namespace Lace.Test.Helper.Fakes.Lace.Builder
{
    public class FakeSourceChain : IBuildSourceChain
    {
        private readonly IAction _action;

        public FakeSourceChain(IAction action)
        {
            _action = action;
        }

        public void Build()
        {
            if (string.IsNullOrEmpty(_action.Name))
            {
                throw new Exception("Action for request is empty");
            }


            SourceChain =
                new FakeSourceSpecification().Specifications.SingleOrDefault(
                    w => w.Key.Equals(_action.Name, StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        public Action<ILaceRequest, NServiceBus.IBus, IProvideResponseFromLaceDataProviders, Guid> SourceChain { get; private set; }


    }
}
