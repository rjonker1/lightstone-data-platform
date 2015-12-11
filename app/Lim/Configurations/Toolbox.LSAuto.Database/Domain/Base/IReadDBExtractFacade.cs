using System.Collections.Generic;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Base
{
    public interface IReadDatabaseExtractFacade
    {
        List<DatabaseExtractDto> GetDataExtracts();
        DatabaseExtractDto GetDataExtract(long id);
    }
}