using System;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class FakeDataProviderResponseRepository : IAmDataProviderResponseRepository
    {
        public IEnumerable<IPointToLaceProvider> DataProviderResponses = Enumerable.Empty<IPointToLaceProvider>();

        public FakeDataProviderResponseRepository()
        {
            DataProviderResponses = new[]
            {
                this[DataProviderName.Ivid],
                this[DataProviderName.IvidTitleHolder],
                this[DataProviderName.LightstoneAuto],
                this[DataProviderName.Rgt],
                this[DataProviderName.RgtVin],
                this[DataProviderName.Audatex],
                this[DataProviderName.PCubedFica],
                this[DataProviderName.SignioDecryptDriversLicense],
                this[DataProviderName.LightstoneProperty],
                this[DataProviderName.LightstoneBusinessCompany],
                this[DataProviderName.LightstoneBusinessDirector],
                this[DataProviderName.BmwFinance]
            };
        }

        public IPointToLaceProvider GetDataProvider(DataProviderName name)
        {
            return new FakeDataProviderResponseRepository()[name];
        }
        public IPointToLaceProvider this[DataProviderName name]
        {
            get
            {
                switch (name)
                {
                    case DataProviderName.Ivid:
                        var ividResponse = Lace.Domain.Core.Entities.IvidResponse.Build("NO_ISSUES", "IVD - 01468460493", "XMC167GP", "CNC407L", "2/18/2014", "SB1KV58E40F039277", "1ZRU041295", "1598", "1276");
                        ividResponse.HasBeenHandled();
                        return ividResponse;
                    case DataProviderName.IvidTitleHolder:
                        var ividTitleHolderResponse = new IvidTitleHolderResponse();
                        ividTitleHolderResponse.Build("WesBank", false, "00009009838", DateTime.Now.AddYears(-10), DateTime.Now.AddYears(-5), "");
                        ividTitleHolderResponse.HasBeenHandled();
                        return ividTitleHolderResponse;
                    case DataProviderName.LightstoneAuto:
                        var lightstoneAutoResponse = new Lace.Domain.Core.Entities.LightstoneAutoResponse(107483, DateTime.Now.Year, "SB1KV58E40F039277", "", "3rd Quarter", "TOYOTA Auris 1.6 RT 5-dr", "Auris 1.6 RT 5-dr", null);
                        lightstoneAutoResponse.HasBeenHandled();
                        return lightstoneAutoResponse;
                    case DataProviderName.Rgt:
                        var rgtResponse = new RgtResponse("TOYOTA", 2008, "Hatch back", "190", "91", "6.2", "10.4", "157", "166", "1598", "Hatch (5-dr)", "Petrol", "Man", "Toyota AURIS", "STANDARD WHITE", "", "", "", "D166", "T05", "Auris");
                        rgtResponse.HasBeenHandled();
                        return rgtResponse;
                    case DataProviderName.RgtVin:
                        var rgtVinResponse = new RgtVinResponse("Super White II", 8, 0, 3, 0, "TOYOTA", "Auris 1.6 RT 5-dr", "Auris", "SB1KV58E40F039277", 2008);
                        rgtVinResponse.HasBeenHandled();
                        return rgtVinResponse;
                    case DataProviderName.Audatex:
                        var audatexResponse = new Lace.Domain.Core.Entities.AudatexResponse(new List<IProvideAccidentClaim>
                        {
                            new AccidentClaim(DateTime.MinValue, string.Empty, string.Empty, DateTime.MinValue,
                                string.Empty,
                                string.Empty, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                                string.Empty,
                                0.0M, 0.0M, DateTime.MinValue, string.Empty, string.Empty, string.Empty, string.Empty)
                        });
                        audatexResponse.HasBeenHandled();
                        return audatexResponse;
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
                    case DataProviderName.BmwFinance:
                        return new BmwFinanceResponse().EmptyBmwFinanceResponse();
                    default:
                        return null;
                }
            }
        }
    }
}