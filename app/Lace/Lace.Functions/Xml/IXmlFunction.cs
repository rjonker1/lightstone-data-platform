using System;

namespace Lace.Functions.Xml
{
    public interface IXmlFunction
    {
        string ObjectToXml<T>(T obj, Type[] expectedTypes = null);
        T XmlToObject<T>(string xml) where T : new();
    }
}
