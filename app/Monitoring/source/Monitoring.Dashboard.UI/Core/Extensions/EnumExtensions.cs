using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Monitoring.Dashboard.UI.Core.Enums;

namespace Monitoring.Dashboard.UI.Core.Extensions
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

        public static string Description(this RequestFieldType requestField)
        {
            var attribute =
                requestField.GetType().GetField(requestField.ToString()).GetCustomAttributes(typeof (EnumMemberAttribute), false).SingleOrDefault() as
                    EnumMemberAttribute;
            return attribute == null ? requestField.ToString() : attribute.Value;
        }
    }
}