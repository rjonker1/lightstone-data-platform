﻿using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Helpers.Extensions;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace PackageBuilder.Core
{
    public class TypeConverter : JsonConverter
    {
        public override bool CanConvert(Type objectType)
        {
            //assume we can convert to anything for now
            return true;
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            return DeserializeObjectByType(reader);
        }
        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            //use the default serialization - it works fine
            serializer.Serialize(writer, value);
        }

        private object DeserializeObjectByType(JsonReader reader)
        {
            var jObject = JObject.Load(reader);
            var json = jObject.ToString();
            var dObject = (dynamic)jObject;
            var type = Type.GetType(dObject.Type.ToString());
            try
            {
                return JsonConvert.DeserializeObject(json, type);
            }
            catch (JsonException exception)
            {
                //this.Error(() => "Could not deserialize command by type: {0} attempting to deserialize by type name {1}".FormatWith(type, typeName), exception);
                return DeserializeObjectByTypeName(json, dObject.Type, dObject.TypeName);
            }
        }

        private object DeserializeObjectByTypeName(string json, string type, string typeName)
        {
            try
            {
                return JsonConvert.DeserializeObject(json, getTypeByName(type)[0]);
            }
            catch (JsonException exception)
            {
                this.Error(() => "Could not deserialize command by type: {0} or type name {1}".FormatWith(type, typeName), exception);
                return null;
            }
        }

        private static Type[] getTypeByName(string className)
        {
            var returnVal = new List<Type>();

            foreach (var a in AppDomain.CurrentDomain.GetAssemblies())
                returnVal.AddRange(a.GetTypes().Where(t => t.Name == className));

            return returnVal.ToArray();
        }
    }
}