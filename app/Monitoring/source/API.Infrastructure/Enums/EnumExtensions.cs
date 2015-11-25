using System;
using System.Linq;
using System.Runtime.Serialization;

namespace Api.Infrastructure.Enums
{
    public static class EnumExtensions
    {
        public static string Checks(this UserAgent agent)
        {
            var attribute =
                agent.GetType().GetField(agent.ToString()).GetCustomAttributes(typeof (EnumMemberAttribute), false).SingleOrDefault() as
                    EnumMemberAttribute;
            return attribute == null ? agent.ToString() : attribute.Value;
        }

        public static bool Exists(this string agent, string parameters)
        {
            var exists = false;
            foreach (var param in parameters.Split(','))
            {
                exists = agent.IndexOf(param, StringComparison.CurrentCultureIgnoreCase) > 0;
                    // .IndexOfAny(param, StringComparer.CurrentCultureIgnoreCase);
                if (exists)
                    break;
            }

            return exists;
        }

       
    }
}