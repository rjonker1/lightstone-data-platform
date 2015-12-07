using System;
using System.Collections.Generic;
using Lim.Dtos;

namespace Toolbox.LightstoneAuto.Domain
{
    public interface IReadModelFacade
    {
        IEnumerable<DataSetDto> GetDataSets();
        //DataSetDetailsDto GetDataSet(Guid id);
    }
}