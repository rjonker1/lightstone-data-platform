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

        public static bool Count(this List<string> agents, string parameters)
        {
            var exists = false;
            foreach (var param in parameters.Split(','))
            {
                exists = agents.Contains(param, StringComparer.CurrentCultureIgnoreCase);
                if(exists)
                    break;
            }

            return exists;
        }
    }
}