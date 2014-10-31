using System;
using System.Runtime.Serialization;

namespace DataPlatform.Shared.ExceptionHandling
{
    [Serializable]
    public class LightstoneAutoException : Exception
    {
        public LightstoneAutoException()
        {
        }

        public LightstoneAutoException(string message) : base(message)
        {
        }

        public LightstoneAutoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected LightstoneAutoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}