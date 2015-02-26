using AutoMapper;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Helpers;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.DataTables
{
    public class DataTablesMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PagedList<NamedEntity>, DataTablesViewModel>()
                .ForMember(d => d.Data, opt => opt.MapFrom(x => x));
        }
    }
}