using System;
using System.Linq;
using DataPlatform.Shared.Entities;
using Lace.Builder;
using Lace.Events;
using Lace.Models.Responses;
using Lace.Request;
using Lace.Response;

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

        public Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; private set; }
    }
}
