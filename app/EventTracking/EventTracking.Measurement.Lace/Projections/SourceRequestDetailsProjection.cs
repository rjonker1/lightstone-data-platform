using EventTracking.Domain.Read.Core;

namespace EventTracking.Measurement.Lace.Projections
{
    public class SourceRequestDetailsProjection
    {
        private readonly IProjectionContext _projectionContext;

        public SourceRequestDetailsProjection(IProjectionContext projectionContext)
        {
            _projectionContext = projectionContext;
        }

        public void Ensure()
        {
            var projectionSource = ProjectionSources.Read("RequestsSentToSources");
            _projectionContext.EnsureProjection("RequestsSentToSources", projectionSource);
        }

    }
}
