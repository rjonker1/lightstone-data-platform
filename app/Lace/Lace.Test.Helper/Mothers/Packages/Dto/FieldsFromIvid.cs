using System;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class RegistrationFieldSource : IDataProvider
    {
        public RegistrationFieldSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class VinFieldSource : IDataProvider
    {

        public VinFieldSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class EngineFieldSource : IDataProvider
    {
        public EngineFieldSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class MakeDescriptionFiledSource : IDataProvider
    {

        public MakeDescriptionFiledSource()
        {
            Id = new Guid("442FA7F8-DEE8-4A85-AC9A-B5DDC7D1209A");
            Name = "Ivid";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }


        public Type ResponseType { get; private set; }
    }
}
