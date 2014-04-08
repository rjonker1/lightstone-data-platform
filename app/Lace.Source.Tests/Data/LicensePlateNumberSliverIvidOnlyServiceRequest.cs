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
                return new string[] { "Ivid"};
            }
        }
    }
}
