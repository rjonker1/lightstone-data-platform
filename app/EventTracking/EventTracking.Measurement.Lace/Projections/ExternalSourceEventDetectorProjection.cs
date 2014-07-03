namespace EventTracking.Measurement.Lace.Projections
{
    public class ExternalSourceEventDetectorProjection
    {
        private readonly IProjectionContext _projectionContext;

        public ExternalSourceEventDetectorProjection(IProjectionContext projectionContext)
        {
            _projectionContext = projectionContext;
        }

        public void Ensure()
        {
            var projectionSource = ProjectionSources.Read("ExternalSourceEventRead");
            _projectionContext.EnsureProjection("ExternalSourceEventRead", projectionSource);
        }

    }
}
