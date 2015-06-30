using System;

namespace UserManagement.Domain.Dtos
{
    public class NamedEntityDto : EntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
    }
}