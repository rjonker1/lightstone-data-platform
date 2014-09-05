using System;

namespace PackageBuilder.Common.Helpers.Extensions
{
    /// <summary>
    /// From StructureMap code
    /// </summary>
    public static class TypeRules
    {
        // Methods
        public static bool CanBeCast(Type pluginType, Type pluggedType)
        {
            if (pluggedType.IsInterface || pluggedType.IsAbstract)
                return false;
            if (noPublicConstructors(pluggedType))
                return false;
            if (IsGeneric(pluginType))
                return GenericsCanBeCast(pluginType, pluggedType);
            return !IsGeneric(pluggedType) && pluginType.IsAssignableFrom(pluggedType);
        }

        public static bool GenericsCanBeCast(Type pluginType, Type pluggedType)
        {
            bool flag;
            try
            {
                flag = checkGenericType(pluggedType, pluginType);
            }
            catch (Exception exception)
            {
                throw new ApplicationException(string.Format("Could not Determine Whether Type '{0}' plugs into Type '{1}'", pluginType.Name, pluggedType.Name), exception);
            }
            return flag;
        }

        private static bool checkGenericType(Type pluggedType, Type pluginType)
        {
            foreach (Type type in pluggedType.GetInterfaces())
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition().Equals(pluginType))
                    return true;
            }
            if (!pluggedType.BaseType.IsGenericType)
                return false;
            var genericTypeDefinition = pluggedType.BaseType.GetGenericTypeDefinition();
            return (genericTypeDefinition.Equals(pluginType) || CanBeCast(pluginType, genericTypeDefinition));
        }

        public static bool IsGeneric(Type pluggedType)
        {
            return pluggedType.IsGenericTypeDefinition || pluggedType.ContainsGenericParameters;
        }

        private static bool noPublicConstructors(Type pluggedType)
        {
            return (pluggedType.GetConstructors().Length == 0);
        }
    }
}