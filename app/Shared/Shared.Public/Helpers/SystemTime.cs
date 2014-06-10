using System;

namespace DataPlatform.Shared.Public.Helpers
{
    public class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;
    }
}