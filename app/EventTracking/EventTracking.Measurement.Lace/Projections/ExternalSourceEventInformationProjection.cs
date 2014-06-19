namespace EventTracking.Measurement.Lace.Projections
{
    public class ExternalSourceEventInformationProjection
    {
        private readonly IProjectionContext _projectionContext;

        public ExternalSourceEventInformationProjection(IProjectionContext projectionContext)
        {
            _projectionContext = projectionContext;
        }

        public void Ensure()
        {
            var projectionSource = ProjectionSources.Read("ExternalSourceEventInformation");
            _projectionContext.EnsureProjection("ExternalSourceEventInformation", projectionSource);
        }

    }
}
