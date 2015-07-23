using DataPlatform.Shared.Enums;

namespace PackageBuilder.Domain.Entities.DataProviders.Write
{
    public class DataProviderConnectionStringRepository
    {
        public string GetDataProviderConnectionStringName(DataProviderName name)
        {
            return new DataProviderConnectionStringRepository()[name];
        }
        public string this[DataProviderName name]
        {
            get
            {
                switch (name)
                {
                    case DataProviderName.Ivid:
                        return "";
                    case DataProviderName.IvidTitleHolder:
                        return "";
                    case DataProviderName.LightstoneAuto:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.Rgt:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.RgtVin:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.Audatex:
                        return "";
                    case DataProviderName.PCubedFica:
                        return "";
                    case DataProviderName.SignioDecryptDriversLicense:
                        return "";
                    case DataProviderName.LightstoneProperty:
                        return "";
                    case DataProviderName.LightstoneBusinessCompany:
                        return "";
                    case DataProviderName.LightstoneBusinessDirector:
                        return "";
                    default:
                        return null;
                }
            }
        }
    }
}