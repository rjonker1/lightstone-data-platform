using System;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IOperationContextManager
    {
        IOperationContext GetCurrent();
    }

    public interface IOperationContext : IDisposable
    {
        String CorrelationId { get; }
        IOperationContext ForOperation(String correlationId);

        void Add(string key, Object value);
        T Get<T>(string key);
    }
}