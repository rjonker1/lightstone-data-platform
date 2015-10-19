using System.Collections.Generic;
using Lace.Toolbox.Database.Dtos;
namespace Lace.Toolbox.Database.Base
{
    public interface IGetCarInformation
    {
        IEnumerable<CarInformationDto> Cars { get; }
        void GetCarInformation(IHaveCarInformation request);
    }
}
