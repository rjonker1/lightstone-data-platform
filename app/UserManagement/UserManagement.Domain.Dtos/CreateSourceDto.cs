using System;
using UserManagement.Domain.Enums;

namespace UserManagement.Domain.Dtos
{
    public class CreateSourceDto : ValueEntityDto
    {
        public CreateSourceType CreateSourceType { get; set; }

        public CreateSourceDto(string value, Type type, CreateSourceType createSourceType) : base(value, type, new Guid())
        {
            CreateSourceType = createSourceType;
        }
    }
}