
namespace EventTracking.Measurement
{
    public interface IProjectionContext
    {
        void EnableProjection(string name);

        void EnsureProjection(string name, string source);

        T GetState<T>(string projectionName);
    }
}
