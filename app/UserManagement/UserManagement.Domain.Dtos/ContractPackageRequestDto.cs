using System;

namespace UserManagement.Domain.Dtos
{
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