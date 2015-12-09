using AutoMapper;
using Lim.Dtos;
using Toolbox.LSAuto.Entities;

namespace Toolbox.LightstoneAuto.Domain.Mapping
{
    public class DataSetMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<DataSet, DataSetDto>();
            Mapper.CreateMap<DataSetDto, DataSet>();

            Mapper.CreateMap<DataField, DataFieldDto>();
            Mapper.CreateMap<DataFieldDto, DataField>();
        }
    }
}
