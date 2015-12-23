using AutoMapper;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class IntegrationContractMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<IntegrationContract, IntegrationContractDto>()
                .ConstructUsing(
                    contract =>
                        IntegrationContractDto.Existing(contract.Id, contract.Contract, 
                        contract.Configuration.Id, contract.IsActive,
                            contract.DateModified, contract.ModifiedBy, contract.ClientCustomerId)).ForAllMembers(opt => opt.Ignore()); ;
            Mapper.CreateMap<IntegrationContractDto, IntegrationContract>();
        }
    }
}