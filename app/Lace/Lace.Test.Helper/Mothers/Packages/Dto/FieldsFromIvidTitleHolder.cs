using System;
using DataPlatform.Shared.Public.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class BankNameFieldSource : IDataSource
    {
        public BankNameFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }


    }

    public class AccountNumberFieldSource : IDataSource
    {
        public AccountNumberFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }


    public class AccountOpenDateFieldSource : IDataSource
    {
        public AccountOpenDateFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }

    public class AccountClosedDateFieldSource : IDataSource
    {
        public AccountClosedDateFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }
    }
}
