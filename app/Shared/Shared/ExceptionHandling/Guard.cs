using System;

namespace DataPlatform.Shared.ExceptionHandling
{
    public static class Guard
    {
        public static void AgainstNull(object obj, string message)
        {
            if (obj == null)
                throw new InvalidOperationException(message);
        }

        public static void Against<T>(bool assertion, string message)
            where T : Exception, new()
        {
            if (assertion)
            {
                var exception = (T)Activator.CreateInstance(typeof(T), message);
                throw exception;
            }
        }

        public static void Against(bool assertion, string message)
        {
            if (assertion)
            {
                throw new InvalidOperationException(message);
            }
        }
    }
}