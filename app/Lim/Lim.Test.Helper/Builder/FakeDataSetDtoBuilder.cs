using System;
using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Test.Helper.Builder
{
    public class FakeDataSetDtoBuilder
    {
        public static DataSetDto ForLsAutoSpecsData(Guid id)
        {
            return new DataSetDto
            {
                Activated = true,
                Description = "LS Auto Spec Export",
                AggregateId = id,
                Name = "LS Auto Specs Export",
                Version = -1,
                DataFields = new List<DataFieldDto>
                {
                    new DataFieldDto()
                    {
                        Id = 0,
                        Activated = true,
                        DateCreated = DateTime.Now.AddDays(-1),
                        Name = "Speed",
                        DisplayName = "Speed",
                        DateModified = DateTime.Now,
                        Selected = true
                    }
                }
            };
        }
    }
}
