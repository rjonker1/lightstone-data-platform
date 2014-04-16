using Lace.Request;
using System;

namespace Lace.Source.Tests.Data
{
    public class LicensePlateNumberSliverAllServicesRequest : ILaceRequest
    {

        public Guid UserId
        {
            get
            {
                return Guid.NewGuid();
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
                return new string[] { "Ivid", "IvidTitleHolder", "RgtVin" };
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
            get { return string.Empty; }
        }

        public string Product
        {
            get
            {
                return "XMC167GP";
            }
        }

        public string ReasonForApplication
        {
            get { return string.Empty; }
        }


        public string UserPassword
        {
            get { throw new NotImplementedException(); }
        }
    }
}
