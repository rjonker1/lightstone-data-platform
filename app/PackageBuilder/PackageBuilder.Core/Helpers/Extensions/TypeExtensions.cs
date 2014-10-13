using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace PackageBuilder.Core.Helpers.Extensions
{
    public static class TypeExtensions
    {
        public static PropertyInfo[] GetPublicProperties(this Type type)
        {
            if (type.IsInterface)
            {
                var propertyInfos = new List<PropertyInfo>();

                var considered = new List<Type>();
                var queue = new Queue<Type>();
                considered.Add(type);
                queue.Enqueue(type);
                while (queue.Count > 0)
                {
                    var subType = queue.Dequeue();
                    foreach (var subInterface in subType.GetInterfaces())
                    {
                        if (considered.Contains(subInterface)) continue;

                        considered.Add(subInterface);
                        queue.Enqueue(subInterface);
                    }

                    var typeProperties = subType.GetProperties(
                        BindingFlags.FlattenHierarchy
                        | BindingFlags.Public
                        | BindingFlags.Instance);

                    var newPropertyInfos = typeProperties
                        .Where(x => !propertyInfos.Contains(x));

                    propertyInfos.InsertRange(0, newPropertyInfos);
                }

                return propertyInfos.ToArray();
            }

            return type.GetProperties(BindingFlags.FlattenHierarchy | BindingFlags.Public | BindingFlags.Instance);
        }

        public static bool CanBeCastTo(this Type pluggedType, Type pluginType)
        {
            return TypeRules.CanBeCast(pluginType, pluggedType);
        }

        public static bool IsNullableType(this Type theType)
        {
            return (theType.IsGenericType && theType.GetGenericTypeDefinition().Equals(typeof(Nullable<>)));
        }

        /// <summary>
        /// Returns the 'real' type of a type, removing any nullable type wrappers
        /// </summary>
        /// <param name="theType"></param>
        /// <returns></returns>
        public static Type GetTypeWithoutNullable(this Type theType)
        {
            return !theType.IsNullable() ? theType : theType.GetGenericArguments()[0];
        }

        public static Type FindClassThatCloses(this Type pluggedType, Type templateType)
        {
            var baseType = pluggedType.BaseType;
            if (baseType == null) return null;
            if (baseType.IsGenericType && (baseType.GetGenericTypeDefinition() == templateType))
                return baseType;
            return baseType != typeof (object) ? baseType.FindClassThatCloses(templateType) : null;
        }

        public static Type FindInterfaceThatCloses(this Type pluggedType, Type templateType)
        {
            if (!pluggedType.IsConcrete()) return null;

            foreach (Type type in pluggedType.GetInterfaces())
            {
                if (type.IsGenericType && (type.GetGenericTypeDefinition() == templateType))
                    return type;
            }
            return pluggedType.BaseType != typeof (object) ? pluggedType.BaseType.FindInterfaceThatCloses(templateType) : null;
        }

        public static string GetFullName(this Type type)
        {
            if (!type.IsGenericType)
                return type.FullName;

            var strArray = Array.ConvertAll<Type, string>(type.GetGenericArguments(), delegate(Type t)
            {
                return t.GetName();
            });
            var str = string.Join(", ", strArray);
            return string.Format("{0}<{1}>", new object[] { type.Name, str });
        }

        public static Type GetInnerTypeFromNullable(this Type nullableType)
        {
            return nullableType.GetGenericArguments()[0];
        }

        public static string GetName(this Type type)
        {
            if (!type.IsGenericType)
                return type.Name;
            var strArray = Array.ConvertAll<Type, string>(type.GetGenericArguments(), delegate(Type t)
            {
                return t.GetName();
            });
            var str = string.Join(", ", strArray);
            return string.Format("{0}<{1}>", new object[] { type.Name, str });
        }

        public static bool IsInterfaceTemplate(this Type pluggedType, Type templateType)
        {
            return pluggedType.IsGenericType && pluggedType.GetGenericTypeDefinition() == templateType;
        }

        public static bool ImplementsInterfaceTemplate(this Type pluggedType, Type templateType)
        {
            if (!pluggedType.IsConcrete()) return false;

            foreach (Type type in pluggedType.GetInterfaces())
                if (type.IsGenericType && (type.GetGenericTypeDefinition() == templateType))
                    return true;

            return false;
        }

        public static bool IsConcrete(this Type type)
        {
            return (!type.IsInterface && !type.IsAbstract);
        }

        public static bool IsConcreteAndAssignableTo(this Type pluggedType, Type pluginType)
        {
            return (pluggedType.IsConcrete() && pluginType.IsAssignableFrom(pluggedType));
        }

        public static bool IsGeneric(this Type type)
        {
            return type.IsGenericTypeDefinition || type.ContainsGenericParameters;
        }

        public static bool IsInNamespace(this Type type, string nameSpace)
        {
            return type.Namespace.StartsWith(nameSpace);
        }

        public static bool IsNullable(this Type type)
        {
            return (type.IsGenericType && (type.GetGenericTypeDefinition() == typeof(Nullable<>)));
        }

        public static bool IsSimple(this Type type)
        {
            if (!type.IsPrimitive && !type.IsString())
                return type.IsEnum;
            return true;
        }

        public static bool IsString(this Type type)
        {
            return type.Equals(typeof(string));
        }

        public static Type FindGenericType(this Type type, Type genericType)
        {
            for (; type != null && type != typeof(object); type = type.BaseType)
            {
                if (type.IsGenericType && type.GetGenericTypeDefinition() == genericType)
                    return type;
                if (genericType.IsInterface)
                {
                    foreach (Type type1 in type.GetInterfaces())
                    {
                        Type genericType1 = type1.FindGenericType(genericType);
                        if (genericType1 != null)
                            return genericType1;
                    }
                }
            }
            return (Type)null;
        }

        public static IEnumerable<Type> FindDerivedTypesFromAssembly(this Assembly assembly, Type baseType, bool classOnly, bool includeAbstractClasses)
        {
            if (assembly == null)
                throw new ArgumentNullException("assembly", "Assembly must be defined");

            if (baseType == null)
                throw new ArgumentNullException("baseType", "Parent Type must be defined");

            // get all the types
            var types = assembly.GetTypes();

            // works out the derived types
            foreach (var type in types)
            {
                // if classOnly, it must be a class
                // useful when you want to create instance
                if (classOnly && !type.IsClass)
                    continue;

                if (!includeAbstractClasses && type.IsAbstract)
                    continue;

                if (baseType.IsInterface)
                {
                    var it = type.GetInterface(baseType.FullName);

                    if (it != null)
                        // add it to result list
                        yield return type;
                }
                else if (type.IsSubclassOf(baseType))
                {
                    // add it to result list
                    yield return type;
                }
            }
        }
    }
}