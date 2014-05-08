using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Lace.Shared.Helpers
{
    public static class XmlFunctions
    {
        public static string ObjectToXml<T>(T obj, Type[] expectedTypes = null)
        {
            var serializer = expectedTypes == null ? new XmlSerializer(typeof(T)) : new XmlSerializer(typeof(T), expectedTypes);

            using (var stringWriter = new StringWriter())
            {
                try
                {
                    serializer.Serialize(stringWriter, obj);
                    return stringWriter.ToString();
                }
                catch
                {
                    return null;
                }
            }
        }


        public static T XmlToObject<T>(string xml) where T : new()
        {
            try
            {
                var serializer = new XmlSerializer(typeof (T));
                using (var stringReader = new StringReader(xml))
                {
                    using (var xmlTextReader = new XmlTextReader(stringReader))
                    {
                        try
                        {
                            var o = (T) serializer.Deserialize(xmlTextReader);
                            return o;
                        }
                        catch
                        {
                            return default(T);
                        }
                    }
                }
            }
            catch
            {
                return default(T);
            }
        }
    }
}
