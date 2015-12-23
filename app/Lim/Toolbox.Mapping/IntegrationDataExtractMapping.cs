using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class IntegrationDataExtractMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IntegrationDataExtract, IntegrationDataExtractDto>()
                .ConstructUsing(
                    c =>
                        IntegrationDataExtractDto.Existing(c.Id, c.Configuration.Id, c.DataExtractId,
                            c.DateCreated, c.CreatedBy, c.DateModified, c.ModifiedBy));

            Mapper.CreateMap<IntegrationDataExtractDto, IntegrationDataExtract>();
        }
    }
}
