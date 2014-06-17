using DataPlatform.Shared.Public.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class RegistrationFieldSource : IDataSource
    {
        public RegistrationFieldSource()
        {
            Id = 1;
            Name = "Ivid";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class VinFieldSource : IDataSource
    {

        public VinFieldSource()
        {
            Id = 1;
            Name = "Ivid";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class EngineFieldSource : IDataSource
    {
        public EngineFieldSource()
        {
            Id = 1;
            Name = "Ivid";
        }

        public int Id { get; set; }

        public string Name { get; set; }
     
    }

    public class MakeDescriptionFiledSource : IDataSource
    {

        public MakeDescriptionFiledSource()
        {
            Id = 1;
            Name = "Ivid";
        }

        public int Id { get; set; }

        public string Name { get; set; }

    }
}
