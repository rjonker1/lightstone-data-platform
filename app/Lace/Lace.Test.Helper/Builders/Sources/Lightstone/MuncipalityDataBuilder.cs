using System.Collections.Generic;
using Lace.Toolbox.Database.Models;

namespace Lace.Test.Helper.Builders.Sources.Lightstone
{
    public class MuncipalityDataBuilder
    {
        public static IEnumerable<Municipality> ForAllMunicipalities()
        {
            return Mothers.Sources.Lightstone.MunicipalityData.ForAllMuncipalities();
        }
    }
}
