using System.Linq;
using System.Runtime.Serialization;
using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Dtos
{
    public static class ResponseStateExtensions
    {
        public static string Description(this DataProviderResponseState value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof (EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;
        }
    }
}