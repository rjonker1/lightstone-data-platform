using System;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class RegistrationFieldSource : IDataSource
    {
        public RegistrationFieldSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class VinFieldSource : IDataSource
    {

        public VinFieldSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class EngineFieldSource : IDataSource
    {
        public EngineFieldSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
     
    }

    public class MakeDescriptionFiledSource : IDataSource
    {

        public MakeDescriptionFiledSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

    }
}
