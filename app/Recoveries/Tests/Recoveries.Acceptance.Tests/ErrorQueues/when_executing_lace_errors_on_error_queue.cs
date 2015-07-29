using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Recoveries.Test.Helper.Mothers.DataProviders;
using Xunit.Extensions;

namespace Recoveries.Acceptance.Tests.ErrorQueues
{
    public class when_executing_lace_errors_on_error_queue :Specification
    {
        private ICollection<IPointToLaceProvider> _responses;
        public override void Observe()
        {
            _responses = LaceExecution.ExecuteVehicleSearch();
        }

        [Observation]
        public void then_resonse_should_be_valid()
        {
            _responses.ShouldNotBeNull();
        }
    }
}
