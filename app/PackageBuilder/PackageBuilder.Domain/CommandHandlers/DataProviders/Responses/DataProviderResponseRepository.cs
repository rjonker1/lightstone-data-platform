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
                    case DataProviderName.Ivid:
                        return new IvidResponse().DefaultIvidResponse();
                    case DataProviderName.IvidTitleHolder:
                        return new IvidTitleHolderResponse();
                    case DataProviderName.LightstoneAuto:
                        return new LightstoneAutoResponse().DefaultLightstoneResponse();
                    case DataProviderName.Rgt:
                        return new RgtResponse();
                    case DataProviderName.RgtVin:
                        return new RgtVinResponse();
                    case DataProviderName.Audatex:
                        return new AudatexResponse().DefaultAudatexResponse();
                    case DataProviderName.PCubedFica:
                        return new PCubedFicaVerficationResponse().DefaultFicaResponse(); 
                    case DataProviderName.PCubedEzScore:
                        return new PCubedEzScoreResponse().DefaultEzScoreResponse();
                    case DataProviderName.SignioDecryptDriversLicense:
                        return new SignioDriversLicenseDecryptionResponse().DefaultSignioDriversLicenseDecryptionResponse();
                    case DataProviderName.LightstoneProperty:
                        return new LightstonePropertyResponse().DefaultLightstonePropertyResponse();
                    case DataProviderName.LightstoneBusinessCompany:
                        return new LightstoneBusinessResponse().LightstoneCompanyResponse();
                    case DataProviderName.LightstoneBusinessDirector:
                        return new LightstoneDirectorResponse().LightstoneCompanyResponse();
                    default:
                        return null;
                }
            }
        }
    }
}