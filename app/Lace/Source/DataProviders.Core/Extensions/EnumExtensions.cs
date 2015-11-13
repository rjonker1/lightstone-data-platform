using System.Linq;
using System.Runtime.Serialization;
using Lace.Domain.DataProviders.Core.Enums;

namespace Lace.Domain.DataProviders.Core.Extensions
{
    public static class EnumExtensions
    {
        public static string Description(this StatusMessageType value)
        {
            var attribute = value.GetType()
                .GetField(value.ToString())
                .GetCustomAttributes(typeof(EnumMemberAttribute), false)
                .SingleOrDefault() as EnumMemberAttribute;
            return attribute == null ? value.ToString() : attribute.Value;
        }
    }
}
