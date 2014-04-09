using System;
using System.IO;
using System.Xml.Serialization;

namespace Lace.Source.Helpers
{
    public static class XmlFunctions
    {
        public static string ObjectToXml<T>(T obj, Type[] expectedTypes = null)
        {
            XmlSerializer serializer = null;

            serializer = expectedTypes != null ? new XmlSerializer(typeof(T), expectedTypes) : new XmlSerializer(typeof(T));

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
    }
}
