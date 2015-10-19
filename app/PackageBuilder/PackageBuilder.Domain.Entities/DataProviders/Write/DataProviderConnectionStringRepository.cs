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
                    case DataProviderName.IVIDVerify_E_WS:
                        return "";
                    case DataProviderName.IVIDTitle_E_WS:
                        return "";
                    case DataProviderName.LSAutoCarStats_I_DB:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.LSAutoSpecs_I_DB:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.LSAutoVINMaster_I_DB:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.Audatex:
                        return "";
                    case DataProviderName.PCubedFica_E_WS:
                        return "";
                    case DataProviderName.PCubedEZScore_E_WS:
                        return "";
                    case DataProviderName.LSAutoDecryptDriverLic_I_WS:
                        return "";
                    case DataProviderName.LSPropertySearch_E_WS:
                        return "";
                    case DataProviderName.LSBusinessCompany_E_WS:
                        return "";
                    case DataProviderName.LSBusinessDirector_E_WS:
                        return "";
                    case DataProviderName.LSConsumerRepair_E_WS:
                        return "";
                    case DataProviderName.BMWFSTitle_E_DB:
                        return "lace/source/database/financed-interests";
                    case DataProviderName.MMCode_E_DB:
                        return "lace/source/database/auto-car-stats";
                    case DataProviderName.LSAutoVIN12_I_DB:
                        return "lace/source/database/auto-car-stats";
                    default:
                        return null;
                }
            }
        }
    }
}