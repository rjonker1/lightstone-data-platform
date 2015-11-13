using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;


namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public interface IAmDataProviderResponseRepository
    {
        IPointToLaceProvider GetDataProvider(DataProviderName name);
    }

    public class DataProviderResponseRepository : IAmDataProviderResponseRepository
    {
        public IPointToLaceProvider GetDataProvider(DataProviderName name)
        {
            return new DataProviderResponseRepository()[name];
        }

        public IPointToLaceProvider this[DataProviderName name]
        {
            get
            {
                switch (name)
                {
                    case DataProviderName.IVIDVerify_E_WS:
                        return new IvidResponse().Default();
                    case DataProviderName.IVIDTitle_E_WS:
                        return new IvidTitleHolderResponse().Default();
                    case DataProviderName.LSAutoCarStats_I_DB:
                        return new LightstoneAutoResponse().Default();
                    case DataProviderName.LSAutoSpecs_I_DB:
                        return new RgtResponse().Default();
                    case DataProviderName.LSAutoVINMaster_I_DB:
                        return new RgtVinResponse().Default();
                    case DataProviderName.Audatex:
                        return new AudatexResponse().Default();
                    case DataProviderName.PCubedFica_E_WS:
                        return new PCubedFicaVerficationResponse().Default();
                    case DataProviderName.PCubedEZScore_E_WS:
                        return new PCubedEzScoreResponse().Default();
                    case DataProviderName.LSAutoDecryptDriverLic_I_WS:
                        return new SignioDriversLicenseDecryptionResponse().Default();
                    case DataProviderName.LSPropertySearch_E_WS:
                        return new LightstonePropertyResponse().Default();
                    case DataProviderName.LSBusinessCompany_E_WS:
                        return new LightstoneBusinessResponse().Default();
                    case DataProviderName.LSBusinessDirector_E_WS:
                        return new LightstoneDirectorResponse().Default();
                    case DataProviderName.LSConsumerRepair_E_WS:
                        return new LightstoneConsumerResponse().Default();
                    case DataProviderName.BMWFSTitle_E_DB:
                        return new BmwFinanceResponse().Default();
                    case DataProviderName.MMCode_E_DB:
                        return new MMCodeResponse().Default();
                    case DataProviderName.LSAutoVIN12_I_DB:
                        return new Vin12Response().Default();
                    default:
                        return null;
                }
            }
        }
    }
}