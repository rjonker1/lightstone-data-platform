using System;

namespace Lim.Web.UI.Models
{
    public class Package
    {
        public const string Select =
            @"select distinct cast(cast(0 as binary) as uniqueidentifier) ContractId, cp.PackageId Id, p.Name from ContractPackage cp join Package p on cp.PackageId = p.Id";
        //@"select distinct cp.ContractId, cp.PackageId, p.Name from ContractPackage cp join Package p on cp.PackageId = p.Id";
        public Package()
        {

        }

        public Package(Guid id, string name, Guid contractId)
        {
            Id = id;
            Name = name;
            ContractId = contractId;
        }

        //public static IEnumerable<Package> Get(IUserManagementRepository repository)
        //{
        //    return repository.Items<Package>(Select, new {});

        //    //return new List<Package>()
        //    //    {
        //    //        new Package(Guid.NewGuid(), "ABC Package"),
        //    //        new Package(Guid.NewGuid(), "DEF Package"),
        //    //        new Package(Guid.NewGuid(), "HIJ Package"),
        //    //        new Package(Guid.NewGuid(), "KLM Package"),
        //    //        new Package(Guid.NewGuid(), "MNO Package"),
        //    //        new Package(Guid.NewGuid(), "PQR Package")
        //    //    };
        //}

        public Guid Id { get; private set; }
        public Guid ContractId { get; private set; }
        public string Name { get; private set; }
    }
}