using System.Collections.Generic;
using Lace.Toolbox.Database.Base;
using Lace.Toolbox.Database.Dtos;

namespace Lace.Toolbox.Database.Queries
{
    public class NullCarInformationQuery : IGetCarInformation
    {
        public void GetCarInformation(IHaveCarInformation request)
        {
            Cars = new List<CarInformationDto>();
        }

        public List<CarInformationDto> Cars { get; private set; }
    }
}