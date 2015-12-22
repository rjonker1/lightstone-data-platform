using System.Collections.Generic;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain.Base
{
    public interface IReadDatabaseViewFacade
    {
        List<DatabaseViewDto> GetDatabaseViews();
        DatabaseViewDto GetDatabaseView(long id);
        DatabaseViewDto GetDatabaseView(string name);
    }
}