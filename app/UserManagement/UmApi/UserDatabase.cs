using System;
using System.Collections.Generic;
using System.Linq;
using Shared.BuildingBlocks.Api.Security;

namespace UmApi
{
    public class UserDatabase
    {
        private static readonly List<Tuple<string, string, string, IEnumerable<string>>> Users = new List<Tuple<string, string, string, IEnumerable<string>>>();

        static UserDatabase()
        {
            Users.Add(new Tuple<string, string, string, IEnumerable<string>>("admin", "password", "4E7106BA-16B6-44F2-AF4C-D1C411440F8E", new[] { "admin", "read", "write" }));
            Users.Add(new Tuple<string, string, string, IEnumerable<string>>("user", "password", "821B362B-E499-4C96-AE4D-2D51C1685E68", new[] { "read" }));
        }

        public static ApiUser GetUserFromApiKey(string apiKey)
        {
            var userRecord = Users.FirstOrDefault(u => u.Item3 == apiKey);

            return userRecord == null
                       ? null
                       : new ApiUser (userRecord.Item1) { Id = new Guid(userRecord.Item3), Claims = userRecord.Item4 };
        }
    }
}