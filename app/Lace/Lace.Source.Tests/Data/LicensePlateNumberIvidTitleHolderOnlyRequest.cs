using System;
using System.Collections.Generic;
using Lace.Request;
using Lace.Tests.Data;

namespace Lace.Source.Tests.Data
{
    public class LicensePlateNumberIvidTitleHolderOnlyRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6");
            }
        }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }



        public string[] Sources
        {
            get
            {
                return new string[] {"IvidTitleHolder"};
            }
        }


        public string UserName
        {
            get { return string.Empty; }
        }

        public string EngineNo
        {
            get { return string.Empty; }
        }

        public string VinOrChassis
        {
            get { return string.Empty; }
        }

        public string Make
        {
            get { return string.Empty; }
        }

        public string RegisterNo
        {
            get { return string.Empty; }
        }

        public string LicenceNo
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string Product
        {
            get { return string.Empty; }
        }

        public string ReasonForApplication
        {
            get { return string.Empty; }
        }

        public string UserEmail
        {
            get
            {
                return "pennyl@lightstone.co.za";
            }
        }

        public string UserPhone
        {
            get
            {
                return null;
            }
        }

        public string Vin
        {
            get
            {
                return "AHT31UNK408007735";
            }
        }


        public string UserFirstName
        {
            get
            {
                return "Penny";
            }
        }

        public string UserLastName
        {
            get { return null; }
        }


        public string SecurityCode
        {
            get { return null; }
        }

        public IField[] Fields
        {
            get
            {
                return new List<IField>()
                {
                    new BankNameField(),
                    new AccountNumberField(),
                    new AccountOpenDateField(),
                    new AccountClosedDateField()

                }.ToArray();
            }
        }
    }
}
