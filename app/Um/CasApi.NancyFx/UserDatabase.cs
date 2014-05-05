using System;
using System.Collections.Generic;
using System.Linq;
using Shared.BuildingBlocks.Api.Security;

namespace UmApi
{
    public class UserDatabase
    {
        static readonly List<Tuple<string, string>> ActiveApiKeys = new List<Tuple<string, string>>();
        private static readonly List<Tuple<string, string>> Users = new List<Tuple<string, string>>();

        static UserDatabase()
        {
            ActiveApiKeys.Add(new Tuple<string, string>("admin", "4E7106BA-16B6-44F2-AF4C-D1C411440F8E"));
            ActiveApiKeys.Add(new Tuple<string, string>("user", "821B362B-E499-4C96-AE4D-2D51C1685E68"));
            Users.Add(new Tuple<string, string>("admin", "password"));
            Users.Add(new Tuple<string, string>("user", "password"));
        }

        public static ApiUser GetUserFromApiKey(string apiKey)
        {
            var activeKey = ActiveApiKeys.FirstOrDefault(x => x.Item2 == apiKey);

            if (activeKey == null)
                return null;

            var userRecord = Users.First(u => u.Item1 == activeKey.Item1);

            return new ApiUser (userRecord.Item1){ Claims = null };
        }
    }
}