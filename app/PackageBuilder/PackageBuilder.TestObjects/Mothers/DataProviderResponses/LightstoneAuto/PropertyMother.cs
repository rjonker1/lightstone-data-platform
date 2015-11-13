using System;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using PackageBuilder.TestObjects.Builders.DataProviderResponses.LightstoneProperty;

namespace PackageBuilder.TestObjects.Mothers.DataProviderResponses.LightstoneAuto
{
    public class PropertyMother
    {
        public static IRespondWithProperty Property
        {
            get
            {
                return new PropertyBuilder()
                    .With(new Guid())
                    .With(true, true)
                    .With(1, 2, 3, 4, 5, 6, 7, 8, 20130101, 1690000, 27.985247, -26.023466, 14d, 15m, 16m, 17m, 18m, 19m, 20m, 21m, 22m, 23m)
                    .With(
                    "Active", 
                    "AdditionalDescription",
                    "B22499/2012",
                    "7902065199085",
                    "WOOLFSON MURRAY GRANT",
                    "MAROELADA",
                    "WATERFORD ESTATE", 
                    "FarmName",
                    "MURRAY",
                    "GRANT",
                    "CITY OF JOHANNESBURG",
                    "PP", 
                    "PostalCode",
                    "FH", 
                    "GA",
                    "20120530",
                    "SecondMiddleName", 
                    "SectionalTitle", 
                    "SectionSchemeNumber", 
                    "StreetNumber", 
                    "StreetType",
                    "MAROELADAL",
                    "WOOLFSON", 
                    "ThirdMiddleName",
                    "610",
                    "MAROELADAL EXT 23",
                    "MAROELADAL EXT 23")
                    .Build();
            }
        }
    }
}