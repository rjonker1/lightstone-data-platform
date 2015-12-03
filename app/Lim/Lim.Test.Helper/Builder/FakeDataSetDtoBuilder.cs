using System;
using System.Collections.Generic;
using Toolbox.LightstoneAuto.Database.Infrastructure.Dto;

namespace Lim.Test.Helper.Builder
{
    public class FakeDataSetDtoBuilder
    {
        public static DataSetDto ForLsAutoSpecsData()
        {
            var id = Guid.NewGuid();

            return new DataSetDto
            {
                Activated = true,
                Description = "LS Auto Spec Export",
                Id = id,
                Name = "LS Auto Specs Export",
                Version = 10000,
                DateCreated = DateTime.Now.AddDays(-1),
                DataFields = new List<DataFieldDto>
                {
                    new DataFieldDto()
                    {
                        Id = id,
                        Activated = true,
                        DateCreated = DateTime.Now.AddDays(-1),
                        Name = "Speed",
                        DataSetId = id,
                        DisplayName = "Speed",
                        DateModified = DateTime.Now,
                        Selected = true
                    }
                }
            };
        }
    }
}
