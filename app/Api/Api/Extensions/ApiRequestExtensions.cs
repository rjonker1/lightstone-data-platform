using Castle.Core.Internal;
using DataPlatform.Shared.Dtos;
using DataPlatform.Shared.Enums;
using DataPlatform.Shared.ExceptionHandling;
using Shared.BuildingBlocks.Api.Validation;

namespace Api.Extensions
{
    public static class ApiRequestExtensions
    {
        public static void Validate(this ApiRequestDto request)
        {
            request.RequestFields.ForEach(f =>
            {
                var valid = ValidationManager.Validate(int.Parse(f.Type), f.Value);
                if (!valid.IsValid)
                    throw new LightstoneAutoException(valid.Error);
            });
        }

        public static void Metadata(this ApiRequestDto request, string fromIpAddress)
        {
            request.SetRequestMetadata(DeviceTypes.ApiClient, SystemType.Api, fromIpAddress);
        }

        public static void ContractVersion(this ApiRequestDto request, long version)
        {
           request.SetContractVersion(version);
        }
    }
}