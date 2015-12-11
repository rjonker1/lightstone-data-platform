using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Toolbox.Database.Queries
{
    public class NullCarInformationQuery : IQueryCarInformation
    {
        public void Get(IHaveCarInformation request)
        {
            Cars = new List<CarInformationDto>();
        }

        public List<CarInformationDto> Cars { get; private set; }
    }
}