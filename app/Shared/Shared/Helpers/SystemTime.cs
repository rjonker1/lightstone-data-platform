using System;

namespace DataPlatform.Shared.Helpers
{
    public class SystemTime
    {
        public static Func<DateTime> Now = () => DateTime.UtcNow;
    }
}