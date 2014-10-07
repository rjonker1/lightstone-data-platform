#region region

using System;
using System.Collections.Generic;

#endregion

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public class TypeCheck
    {
        #region Public Methods

        /// <summary>
        /// Check if is Nullable
        /// </summary>
        public static bool IsNullable(Type type)
        {
            return type == null || type.IsGenericType && type.GetGenericTypeDefinition() == typeof(Nullable<>);
        }

        /// <summary>
        /// Check if is IEnumerable
        /// </summary>
        public static bool IsGenericEnumerable(Type type)
        {
            var genArgs = type.GetGenericArguments();
            if (genArgs.Length == 1 && typeof(IEnumerable<>).MakeGenericType(genArgs).IsAssignableFrom(type))
                return true;
            else
                return type.BaseType != null && IsGenericEnumerable(type.BaseType);
        }

        #endregion
    }
}
