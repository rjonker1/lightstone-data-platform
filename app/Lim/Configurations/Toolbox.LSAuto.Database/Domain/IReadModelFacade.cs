using System;
using System.Collections.Generic;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;

namespace Toolbox.LightstoneAuto.Database.Domain
{
    public interface IReadModelFacade
    {
        IEnumerable<DataSetDto> GetDataSets();
        //DataSetDetailsDto GetDataSet(Guid id);
    }
}