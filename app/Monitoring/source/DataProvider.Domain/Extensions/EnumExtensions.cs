using System.Linq;
using System.Runtime.Serialization;
using DataProvider.Domain.Enums;

namespace DataProvider.Domain.Extensions
{
    public static class EnumExtensions
    {
        public static string Description(this RequestFieldType requestField)
        {
            var attribute =
                requestField.GetType().GetField(requestField.ToString()).GetCustomAttributes(typeof(EnumMemberAttribute), false).SingleOrDefault() as
                    EnumMemberAttribute;
            return attribute == null ? requestField.ToString() : attribute.Value;
        }
    }
}
