using System;
using System.Collections.Generic;
using System.Linq;
using PackageBuilder.Domain.Entities.Packages.WriteModels;
using PackageBuilder.TestObjects.Mothers;
using Shared.BuildingBlocks.Api;

namespace Api.Domain.Verification.Fakes
{
    public class FakePackageBuilderApi : IPbApiClient
    {

        //private IEnumerable<KeyValuePair<Guid, IPackage>> PacakgeBuilderDatabase = new Dictionary<Guid, IPackage>()
        //{
        //    {
        //        Guid.NewGuid(), WritePackageBuilder.
        //    }
        //};

        public IEnumerable<KeyValuePair<Guid, IPackage>> PackageDatabase
        {
            get
            {
                return new Dictionary<Guid, IPackage>()
                {
                    {
                        new Guid("EB49A837-D9E3-4F2A-8DC9-2CB0BB5D48E2"), WritePackageMother.LicenseScanPackage
                    }
                };
            }
        }

        public T Get<T>(string token, string resource = "", object body = null) where T : new()
        {
            return (T)PackageDatabase.FirstOrDefault(w => w.Key == new Guid(resource)).Value;
        }

        public string Get(string token, string resource = "", object body = null)
        {
            throw new NotImplementedException();
        }

        public T Post<T>(string token, string resource = "", object body = null) where T : new()
        {
            throw new NotImplementedException();
        }

        public string Post(string token, string resource = "", object body = null)
        {
            throw new NotImplementedException();
        }
    }
}