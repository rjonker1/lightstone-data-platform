using System.Data;
using System.Linq;
using Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Extensions;

namespace Lace.Domain.DataProviders.Lightstone.Business.Company.Infrastructure.Dto
{
    public class Company
    {
        private Company(long companyId, string name, string regNumber, string vatNumber, string statusCode)
        {
            CompanyId = companyId;
            Name = name;
            RegNumber = regNumber;
            VatNumber = vatNumber;
            StatusCode = statusCode;
        }

        public static Company GetFromDataset(DataSet dataSet)
        {
            return dataSet.Tables["companies"]
                .AsEnumerable()
                .Select(
                    s =>
                        new Company(s.GetLongRowValue("companyid"), s.GetStringValue("companyname"), s.GetStringValue("companyregnumber"),
                            s.GetStringValue("VatNo"), s.GetStringValue("StatusCode")))
                .FirstOrDefault();
        }

        public bool Valid()
        {
            return CompanyId > 0;
        }

        public long CompanyId { get; private set; }
        public string Name { get; private set; }
        public string RegNumber { get; private set; }
        public string VatNumber { get; private set; }
        public string StatusCode { get; private set; }
    }
}
