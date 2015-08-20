using AutoMapper;
using DataPlatform.Shared.Dtos.RequestInfo;
using UserManagement.Domain.Entities;

namespace UserManagement.Api.Helpers.AutoMapper.Maps.RequestInfo
{
    public class RequestInfoMap : ICreateAutoMapperMaps
    {
        public void CreateMaps()
        {
            Mapper.CreateMap<User, RequestInfoDto>();
            Mapper.CreateMap<Customer, RequestInfoCustomerDto>();
            Mapper.CreateMap<Contract, RequestInfoContractDto>();
            Mapper.CreateMap<Package, RequestInfoPackageDto>();
            //Mapper.CreateMap<Re, RequestInfoPackageDto>();
        }
    }
}