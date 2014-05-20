using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data
{
    public class AccidentClaimSource : IDataSource
    {

        public AccidentClaimSource()
        {
            Id = 4;
            Name = "Audatex";
        }

        public int Id { get; set; }

        public string Name { get; set; }


    }
}
