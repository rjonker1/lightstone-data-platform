using System;
using FluentNHibernate;
using FluentNHibernate.Conventions;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class CustomForeignAndSubclassKeyConvention : ForeignKeyConvention 
    {
        protected override string GetKeyName(Member property, Type type)
        {
            if (property == null)
            {
                //Can't use generic types as column names - not valid SQL
                if (type.IsGenericType)
                    return GetKeyName(property, type.BaseType);
                return type.Name + "Id";
            }
            
            return property.Name + "Id";  
        }
    }
}