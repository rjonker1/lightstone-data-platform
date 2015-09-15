using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

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
                        return new IvidResponse().DefaultIvidResponse();
                    case DataProviderName.IVIDTitle_E_WS:
                        return new IvidTitleHolderResponse();
                    case DataProviderName.LSAutoCarStats_I_DB:
                        return new LightstoneAutoResponse().DefaultLightstoneResponse();
                    case DataProviderName.LSAutoSpecs_I_DB:
                        return new RgtResponse();
                    case DataProviderName.LSAutoVINMaster_I_DB:
                        return new RgtVinResponse();
                    case DataProviderName.Audatex:
                        return new AudatexResponse().DefaultAudatexResponse();
                    case DataProviderName.PCubedFica_E_WS:
                        return new PCubedFicaVerficationResponse().DefaultFicaResponse();
                    case DataProviderName.PCubedEZScore_E_WS:
                        return new PCubedEzScoreResponse().DefaultEzScoreResponse();
                    case DataProviderName.LSAutoDecryptDriverLic_I_WS:
                        return new SignioDriversLicenseDecryptionResponse().DefaultSignioDriversLicenseDecryptionResponse();
                    case DataProviderName.LSPropertySearch_E_WS:
                        return new LightstonePropertyResponse().DefaultLightstonePropertyResponse();
                    case DataProviderName.LSBusinessCompany_E_WS:
                        return new LightstoneBusinessResponse().LightstoneCompanyResponse();
                    case DataProviderName.LSBusinessDirector_E_WS:
                        return new LightstoneDirectorResponse().LightstoneCompanyResponse();
                    case DataProviderName.LSConsumerRepair_E_WS:
                        return new LightstoneConsumerResponse().EmptyLightstoneConsumerSpecifications();
                    case DataProviderName.BMWFSTitle_E_DB:
                        return new BmwFinanceResponse().EmptyBmwFinanceResponse();
                    default:
                        return null;
                }
            }
        }
    }
}