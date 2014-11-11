using System.Collections.Generic;
using System.Linq;

namespace DataPlatform.Shared.Helpers.Builders
{
    public static class LinqList
    {
        public static IEnumerable<T> Build<T>(params T[] objs)
        {
            return objs.ToList();
        }
    }
}