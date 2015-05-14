using System;
using System.Collections.Generic;
using Lim.Domain.Respository.Dto;

namespace Lim.Fake.Database
{
    public class FakeLimRepo
    {
        public readonly List<Contract> Contracts = new List<Contract>()
        {
            new Contract(new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Contract 1",000001,Guid.NewGuid(),new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Client 1", "Package 1"),
            new Contract(new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Contract 1",000001,Guid.NewGuid(),new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Client 1", "Package 2"),
            new Contract(new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Contract 1",000001,Guid.NewGuid(),new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Client 1", "Package 3"),
            new Contract(new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Contract 1",000001,Guid.NewGuid(),new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Client 1", "Package 4"),


            new Contract(new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Contract 2",000001,Guid.NewGuid(),new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Client 2", "Package 5"),
            new Contract(new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Contract 2",000001,Guid.NewGuid(),new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Client 2", "Package 6"),
            new Contract(new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Contract 2",000001,Guid.NewGuid(),new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Client 2", "Package 7"),
            new Contract(new Guid("85FA96F5-771C-45C2-B588-A9C906789561"),"Contract 2",000001,Guid.NewGuid(),new Guid("713669A9-1506-42AA-88A6-80EDB14757DC"),"Client 2", "Package 8"),

        };
    }
}