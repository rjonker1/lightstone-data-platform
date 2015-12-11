using System;
using System.Collections.Generic;
using Lim.Dtos;

namespace Lim.Test.Helper.Builder
{
    public class FakeDataSetDtoBuilder
    {
        public static DatabaseExtractDto ForLsAutoSpecsData(Guid id)
        {
            return new DatabaseExtractDto
            {
                Activated = true,
                Description = "LS Auto Spec Export",
                AggregateId = id,
                Name = "LS Auto Specs Export",
                Version = -1,
                Fields = new List<DatabaseExtractFieldDto>
                {
                    new DatabaseExtractFieldDto()
                    {
                        Id = 0,
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
