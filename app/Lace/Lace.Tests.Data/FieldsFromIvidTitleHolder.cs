using Lace.Request;

namespace Lace.Tests.Data
{
    public class BankNameField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "BankName";
            }
        }
    }

    public class AccountNumberField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "AccountNumber";
            }
        }
    }


    public class AccountOpenDateField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "AccountOpenDate";
            }
        }
    }

    public class AccountClosedDateField : IField
    {
        public int SourceId
        {
            get
            {
                return 2;
            }
        }

        public string Name
        {
            get
            {
                return "AccountClosedDate";
            }
        }
    }
}
