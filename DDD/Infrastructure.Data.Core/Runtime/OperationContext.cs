using System;
using System.Collections.Generic;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Runtime
{
    public class OperationContext : IOperationContext
    {
        private readonly Dictionary<String, Object> data = new Dictionary<string, object>();

        public void Dispose()
        {
            CorrelationId = null;
            data.Clear();
        }

        public IOperationContext ForOperation(string correlationId)
        {
            //Ensure.That( correlationId ).Named( () => correlationId ).IsNotNullNorEmpty();
            Ensure.That(CorrelationId).Is(null);

            CorrelationId = correlationId;

            return this;
        }


        public string CorrelationId { get; private set; }

        public void Add(string key, object value)
        {
            data.Add(key, value);
        }

        public T Get<T>(string key)
        {
            return (T) data[key];
        }
    }
}