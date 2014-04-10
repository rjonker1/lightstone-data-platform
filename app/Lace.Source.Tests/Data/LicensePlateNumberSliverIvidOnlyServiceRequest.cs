using Lace.Request;
using System;

namespace Lace.Source.Tests.Data
{
    class LicensePlateNumberSliverIvidOnlyServiceRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return new Guid("4A17B499-845F-43E2-AA2F-CFCB06920AB6");
            }
        }

        public string CompanyId
        {
            get
            {
                return string.Empty;
            }
        }

        public string ContractId
        {
            get
            {
                return string.Empty;
            }
        }

        public DateTime RequestDate
        {
            get
            {
                return DateTime.Now;
            }
        }

        public string LicensePlateNumber
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string[] Sources
        {
            get
            {
                return new string[] { "Ivid"};
            }
        }


        public string UserName
        {
            get { return "pennyl@lightstone.co.za"; }
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
            get { return string.Empty; }
        }

        public string Product
        {
            get { return string.Empty; }
        }

        public string ReasonForApplication
        {
            get { return string.Empty; }
        }

       
    }
}
