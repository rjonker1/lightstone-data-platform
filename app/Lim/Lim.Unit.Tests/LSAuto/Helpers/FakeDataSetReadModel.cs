using System;
using System.Collections.Generic;
using Lim.Test.Helper.Fakes.Repository;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;

namespace Lim.Unit.Tests.LSAuto.Helpers
{
    public class FakeDataSetReadModel : IReadModelFacade
    {
        public IEnumerable<DataSetDto> GetDataSets()
        {
            return FakeDatabase.List;
        }

        public DataSetDetailsDto GetDataSet(Guid id)
        {
            return FakeDatabase.Details[id];
        }
    }
}
