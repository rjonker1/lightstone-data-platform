using System.Collections.Generic;
using Lace.Toolbox.Database.Dtos;
namespace Lace.Toolbox.Database.Base
{
    public interface IQueryCarInformation
    {
        List<CarInformationDto> Cars { get; }
        void Get(IHaveCarInformation request);
    }
}
