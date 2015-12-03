using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Reflection;

namespace Lim.Domain.Extensions
{
    class ReflectionHelper : DynamicObject
    {
        private static readonly IDictionary<Type, IDictionary<string, IProperty>> PropertiesOnType = new ConcurrentDictionary<Type, IDictionary<string, IProperty>>();
        interface IProperty
        {
            string Name { get; }
            object GetValue(object @object, object[] index);
            void SetValue(object @object, object @value, object[] index);
        }

        class  Property : IProperty
        {
            internal PropertyInfo PropertyInfo { get; set; }
            public string Name
            {
                get { return PropertyInfo.Name; }
            }

            public object GetValue(object @object, object[] index)
            {
                return PropertyInfo.GetValue(@object, index);
            }

            public void SetValue(object @object, object value, object[] index)
            {
                PropertyInfo.SetValue(@object, @value, index);
            }
        }

        class Field : IProperty
        {
            internal FieldInfo FieldInfo { get; set; }


            string IProperty.Name
            {
                get { return FieldInfo.Name; }
            }

            object IProperty.GetValue(object @object, object[] index)
            {
                return FieldInfo.GetValue(@object);
            }

            void IProperty.SetValue(object @object, object value, object[] index)
            {
                FieldInfo.SetValue(@object, @value);
            }
        }

        private object RealObject { get; set; }
        private const System.Reflection.BindingFlags BindingFlags = System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic;

        private IProperty GetProperty(string propertyName)
        {
            // Get the list of properties and fields for this type
           var typeProperties = GetTypeProperties(RealObject.GetType());

            // Look for the one we want
            IProperty property;
            if (typeProperties.TryGetValue(propertyName, out property))
            {
                return property;
            }

            // The property doesn't exist

            // Get a list of supported properties and fields and show them as part of the exception message
            // For fields, skip the auto property backing fields (which name start with <)
            var propNames = typeProperties.Keys.Where(name => name[0] != '<').OrderBy(name => name);
            throw new ArgumentException(
                string.Format(
                "The property {0} doesn't exist on type {1}. Supported properties are: {2}",
                propertyName, RealObject.GetType(), String.Join(", ", propNames)));
        }

        private static IDictionary<string, IProperty> GetTypeProperties(Type type)
        {
            // First, check if we already have it cached
            IDictionary<string, IProperty> typeProperties;
            if (PropertiesOnType.TryGetValue(type, out typeProperties))
            {
                return typeProperties;
            }

            // Not cache, so we need to build it

            typeProperties = new ConcurrentDictionary<string, IProperty>();

            // First, add all the properties
            foreach (var prop in type.GetProperties(BindingFlags).Where(p => p.DeclaringType == type))
            {
                typeProperties[prop.Name] = new Property() { PropertyInfo = prop };
            }

            // Now, add all the fields
            foreach (var field in type.GetFields(BindingFlags).Where(p => p.DeclaringType == type))
            {
                typeProperties[field.Name] = new Field() { FieldInfo = field };
            }

            // Finally, recurse on the base class to add its fields
            if (type.BaseType != null)
            {
                foreach (var prop in GetTypeProperties(type.BaseType).Values)
                {
                    typeProperties[prop.Name] = prop;
                }
            }

            // Cache it for next time
            PropertiesOnType[type] = typeProperties;

            return typeProperties;
        }

        private IProperty GetIndexProperty()
        {
            // The index property is always named "Item" in C#
            return GetProperty("Item");
        }

        private static object InvokeMemberOnType(Type type, object target, string name, object[] args)
        {
            try
            {
                return type.InvokeMember(
                    name,
                    BindingFlags.InvokeMethod | BindingFlags,
                    null,
                    target,
                    args);
            }
            catch (MissingMethodException)
            {
                return type.BaseType != null ? InvokeMemberOnType(type.BaseType, target, name, args) :  null;
            }
        }

        public static object WrapObjectIfNeeded(object @object)
        {
            if (@object == null || @object.GetType().IsPrimitive || @object is string)
                return @object;
            return new ReflectionHelper() {RealObject = @object};
        }

        public override bool TryGetMember(GetMemberBinder binder, out object result)
        {
            var prop = GetProperty(binder.Name);
            result = prop.GetValue(RealObject, index: null);
            result = WrapObjectIfNeeded(result);
            return true;
        }

        public override bool TrySetMember(SetMemberBinder binder, object @value)
        {
            var prop = GetProperty(binder.Name);
            prop.SetValue(RealObject, @value, index: null);
            return true;
        }
        public override bool TryGetIndex(GetIndexBinder binder, object[] indexes, out object result)
        {
            var prop = GetIndexProperty();
            result = prop.GetValue(RealObject, indexes);
            result = WrapObjectIfNeeded(result);
            return true;
        }

        public override bool TrySetIndex(SetIndexBinder binder, object[] indexes, object value)
        {
            var prop = GetIndexProperty();
            prop.SetValue(RealObject, value, indexes);
            return true;
        }

        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            result = InvokeMemberOnType(RealObject.GetType(), RealObject, binder.Name, args);
            result = WrapObjectIfNeeded(result);
            return true;
        }

        public override bool TryConvert(ConvertBinder binder, out object result)
        {
            result = Convert.ChangeType(RealObject, binder.Type);
            return true;
        }

        public override string ToString()
        {
            return RealObject.ToString();
        }
    }
}
