using System;
using System.Collections.Generic;
using System.Linq;

namespace PackageBuilder.Core.Helpers
{
    public class TypeHelper
    {
        /// <summary>
        /// Gets a all Type instances matching the specified class name with just non-namespace qualified class name.
        /// </summary>
        /// <param name="className">Name of the class sought.</param>
        /// <returns>Types that have the class name specified. They may not be in the same namespace.</returns>
        public static Type[] GetTypeByName(string className)
        {
            var returnVal = new List<Type>();

            foreach (var assemblyTypes in AppDomain.CurrentDomain.GetAssemblies().Select(a => a.GetTypes()))
                returnVal.AddRange(assemblyTypes.Where(t => t.Name == className));

            return returnVal.ToArray();
        } 
    }
}