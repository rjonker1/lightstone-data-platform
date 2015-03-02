using System;

namespace UserManagement.Domain.Dtos
{
    public class NamedEntityDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string AssemblyQualifiedName { get; set; }
    }
}