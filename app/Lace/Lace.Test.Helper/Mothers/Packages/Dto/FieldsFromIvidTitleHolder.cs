using System;
using DataPlatform.Shared.Entities;

namespace Lace.Test.Helper.Mothers.Packages.Dto
{
    public class BankNameFieldSource : IDataProvider
    {
        public BankNameFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
      
    }

    public class AccountNumberFieldSource : IDataProvider
    {
        public AccountNumberFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }


    public class AccountOpenDateFieldSource : IDataProvider
    {
        public AccountOpenDateFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }

    public class AccountClosedDateFieldSource : IDataProvider
    {
        public AccountClosedDateFieldSource()
        {
            Id = new Guid("26CC03EB-99FC-4508-86B8-775F1B61163B");
            Name = "Ivid Title Holder";
        }

        public Guid Id { get; set; }

        public string Name { get; set; }

        public Type ResponseType { get; private set; }
    }
}
