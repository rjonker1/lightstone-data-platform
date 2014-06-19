
namespace EventTracking.Domain.Read.Core
{
    public interface IProjectionContext
    {
        void EnableProjection(string name);

        void EnsureProjection(string name, string source);

        T GetState<T>(string projectionName);
    }
}
