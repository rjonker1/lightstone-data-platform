using System;
using System.Collections.Generic;

namespace Lim.Web.UI.Models
{
    public class Package
    {
        public Package(Guid id, string name)
        {
            Id = id;
            Name = name;
        }

        public static List<Package> Get()
        {
            return new List<Package>()
                {
                    new Package(Guid.NewGuid(), "ABC Package"),
                    new Package(Guid.NewGuid(), "DEF Package"),
                    new Package(Guid.NewGuid(), "HIJ Package"),
                    new Package(Guid.NewGuid(), "KLM Package"),
                    new Package(Guid.NewGuid(), "MNO Package"),
                    new Package(Guid.NewGuid(), "PQR Package")
                };
        }

        public Guid Id { get; private set; }
        public string Name { get; private set; }
    }
}