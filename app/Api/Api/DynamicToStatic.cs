using System.Collections.Generic;
using AutoMapper;

namespace Api
{
    public static class DynamicToStatic
    {
        public static T ToStatic<T>(object expando)
        {
            var entity = Mapper.DynamicMap<T>(expando);

            //ExpandoObject implements dictionary
            var properties = expando as IDictionary<string, object>;

            if (properties == null)
                return entity;

            foreach (var entry in properties)
            {
                var propertyInfo = entity.GetType().GetProperty(entry.Key);
                if (propertyInfo != null)
                    propertyInfo.SetValue(entity, entry.Value, null);
            }
            return entity;
        }
    }
}