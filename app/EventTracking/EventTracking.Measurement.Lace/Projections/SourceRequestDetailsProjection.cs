using EventTracking.Domain.Read.Core;
using EventTracking.Projections.Sources;

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
            var projectionSource = ProjectionSources.Read("CompiledRequestSourcesInformationPerRequest");
            _projectionContext.EnsureProjection("CompiledRequestSourcesInformationPerRequest", projectionSource);
        }

    }
}
