using System;
using System.Collections.Generic;
using Lim.Domain.Models;

namespace Lim.Test.Helper.Fakes
{
    public class FakeTransactions
    {
        public static List<PackageTransaction> ForPushApi()
        {
            return new List<PackageTransaction>()
            {
                new PackageTransaction(Guid.NewGuid(), Guid.NewGuid(), "user", Guid.NewGuid(), 12333, DateTime.Now, Guid.NewGuid(), "[{ }]",
                    true)
            };
        }
    }
}