using System.Text;
using AutoMapper;
using Lim.Domain.Extensions;
using Lim.Dtos;
using Lim.Entities;

namespace Toolbox.Mapping
{
    public class PackageResponseMapping : Profile
    {
        protected override void Configure()
        {
            Mapper.CreateMap<PackageResponse, PackageTransactionDto>()
                .ConstructUsing(
                    package =>
                        PackageTransactionDto.Set(package.PackageId, package.Userid, package.Username, package.ContractId, package.AccountNumber,
                            package.ResponseDate,
                            package.RequestId,
                            GetPayload(package.Payload, package.HasResponse), package.HasResponse, package.CommitDate)).ForAllMembers(opt => opt.Ignore()); ;

            Mapper.CreateMap<PackageTransactionDto, PackageResponse>();
        }

        private static string GetPayload(byte[] payload, bool hasResponse)
        {
            if (!hasResponse || payload == null || payload.Length == 0)
                return "[{'Error': 'Report could not be generated'}]";

            return Encoding.UTF8.GetString(payload).RemoveNewLine();
        }
    }
}
