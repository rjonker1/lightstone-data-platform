using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace LightstoneApp.Infrastructure.Data.Core.Extensions
{
    /// <summary>
    ///     Define extension methods in List class
    /// </summary>
    public static class ListExtensions
    {
        /// <summary>
        ///     Extensor Method for translate a list into a InMemoryObjectSet.
        ///     This extension method is only for testing purposed.
        /// </summary>
        /// <typeparam name="T">Typeof elements</typeparam>
        /// <param name="list">List to translate into a IObjectSet</param>
        /// <returns>InMemoryObjectSet</returns>
        [SuppressMessage("Microsoft.Design", "CA1002:DoNotExposeGenericLists")]
        public static MemorySet<T> ToMemorySet<T>(this List<T> list)
            where T : class
        {
            return new MemorySet<T>(list);
        }
    }
}