using AutoMapper;
using DataPlatform.Shared.Helpers;
using UserManagement.Api.ViewModels;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.DataTables
{
    public class DataTablesMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<PagedList<ValueEntity>, DataTablesViewModel>()
                .ForMember(d => d.Data, opt => opt.MapFrom(x => x));
        }
    }
}