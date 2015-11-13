using Lace.Domain.Core.Contracts.DataProviders.Business;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneBusinessCompany;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class CompanyMother
    {
        public static IProvideCompany Company
        {
            get
            {
                return new CompanyBuilder()
                    .With(3479505)
                    .With(true)
                    .With(10, 20, 30, 40)
                    .With(
                        "2010/09/09", 
                        "LIGHTSTONE AUTO", 
                        "2010/018608/07", 
                        "ConversionNumber", 
                        "ZA", 
                        "South Africa", 
                        "Private Company (Pty) Ltd)", 
                        "2010/09/08", 
                        "2",
                        "2010/09/09",
                        "2010/09/10",
                        "2010/018608/06",
                        "FERN GLEN FERNRIDGE OFFICE PARK",
                        "5 HUNTER STREET",
                        "FERNDALE", 
                        "Gauteng",
                        "2194",
                        "P O BOX 418",
                        "PINEGOWRIE",
                        "PostalAddress3",
                        "PostalAddress4", 
                        "2123", 
                        "7", 
                        "Gauteng",
                        "2010/09/11",
                        "(Pty) Ltd", 
                        "ShortName",
                        "SicCode", 
                        "SicDescription",
                        "03",
                        "In Business",
                        "2010/09/12",
                        "9853212158", 
                        "TranslatedName",
                        "2010/09/13",
                        "false"
                    )
                    .Build();
            }
        }
    }
}