using System;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.Dtos
{
    public class ContractPackageResponseDto
    {
        public Guid ContractId { get; private set; }
        public Package Package { get; private set; }

        public ContractPackageResponseDto(Guid contractDurationId, Package package)
        {
            ContractId = contractDurationId;
            Package = package;
        }

        public ContractPackageResponseDto()
        {

        }
    }

    public class ContractPackageRequestDto
    {
        public Guid ContractId { get; private set; }

        public ContractPackageRequestDto(Guid contractDurationId)
        {
            ContractId = contractDurationId;
        }

        public ContractPackageRequestDto()
        {

        }
    }
}
