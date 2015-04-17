using System;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Dtos
{
    public class PlatformStatusDto : ValueEntityDto
    {
        public PlatformStatusType PlatformStatusType { get; set; }

        public PlatformStatusDto(string value, Type type, PlatformStatusType platformStatusType)
            : base(value, type, new Guid())
        {
            PlatformStatusType = platformStatusType;
        }
    }
}