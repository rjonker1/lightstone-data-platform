using System;
using System.Runtime.Serialization;

namespace Recoveries
{
    [Serializable]
    public class EasyNetQException : Exception
    {
        public EasyNetQException() { }
        public EasyNetQException(string message) : base(message) { }
        public EasyNetQException(string message, Exception inner) : base(message, inner) { }

        protected EasyNetQException(
            SerializationInfo info,
            StreamingContext context)
            : base(info, context) { }
    }
}
