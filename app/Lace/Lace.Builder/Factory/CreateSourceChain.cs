using System;
using System.Linq;
using Common.Logging;
using DataPlatform.Shared.Entities;
using Lace.Builder.Specifications;
using Lace.Events;
using Lace.Request;
using Lace.Response;

namespace Lace.Builder.Factory
{
    public class CreateSourceChain : IBuildSourceChain
    {
        private readonly IAction _action;
        private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public CreateSourceChain(IAction action)
        {
            _action = action;
        }

        public void Build()
        {
            if (string.IsNullOrEmpty(_action.Name))
            {
                Log.Error("Action for request is empty. Source chain cannot be built");
                throw new Exception("Action for request is empty");
            }

            Log.ErrorFormat("Building source chain for acton {0}", _action.Name);

            SourceChain =
                new SourceSpecification().Specifications.SingleOrDefault(
                    w => w.Key.Equals(_action.Name, StringComparison.CurrentCultureIgnoreCase)).Value;
        }

        public Action<ILaceRequest, ILaceEvent, ILaceResponse> SourceChain { get; private set; }
    }
}
