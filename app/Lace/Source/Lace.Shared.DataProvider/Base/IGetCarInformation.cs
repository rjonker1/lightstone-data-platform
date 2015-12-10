using System.Collections.Generic;
using Lace.Toolbox.Database.Dtos;
namespace Lace.Toolbox.Database.Base
{
    public interface IGetCarInformation
    {
        List<CarInformationDto> Cars { get; }
        void GetCarInformation(IHaveCarInformation request);
    }
}
