using EventTracking.Domain.Read.Core;

namespace EventTracking.Measurement.Lace.Projections
{
    public class SourceRequestExecutionTimesProjection
    {
        private readonly IProjectionContext _projectionContext;

        public SourceRequestExecutionTimesProjection(IProjectionContext projectionContext)
        {
            _projectionContext = projectionContext;
        }

        public void Ensure()
        {
            var projectionSource = ProjectionSources.Read("SourceRequestExecutionTimes");
            _projectionContext.EnsureProjection("SourceRequestExecutionTimes", projectionSource);
        }

    }
}
