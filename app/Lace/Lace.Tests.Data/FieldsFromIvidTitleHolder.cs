using DataPlatform.Shared.Public.Entities;

namespace Lace.Tests.Data
{
    public class BankNameFieldSource : IDataSource
    {
        public BankNameFieldSource()
        {
            Id = 2;
            Name = "Ivid Title Holder";
        }

        public int Id { get; set; }

        public string Name { get; set; }


    }

    public class AccountNumberFieldSource : IDataSource
    {
        public AccountNumberFieldSource()
        {
            Id = 2;
            Name = "Ivid Title Holder";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }


    public class AccountOpenDateFieldSource : IDataSource
    {
        public AccountOpenDateFieldSource()
        {
            Id = 2;
            Name = "Ivid Title Holder";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }

    public class AccountClosedDateFieldSource : IDataSource
    {
        public AccountClosedDateFieldSource()
        {
            Id = 2;
            Name = "Ivid Title Holder";
        }

        public int Id { get; set; }

        public string Name { get; set; }
    }
}
