using System;
using System.Runtime.Serialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    [Serializable]
    public class ConcurrencyException : Exception
    {
        public ConcurrencyException() { }

        public ConcurrencyException(string message) : base(message) { }

        public ConcurrencyException(string message, Exception inner) : base(message, inner) { }

        protected ConcurrencyException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }
}
