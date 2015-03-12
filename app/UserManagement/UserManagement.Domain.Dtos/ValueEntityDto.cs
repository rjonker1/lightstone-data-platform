using System;
using System.ComponentModel.DataAnnotations;

namespace UserManagement.Domain.Dtos
{
    public class ValueEntityDto
    {
        public Guid Id { get; set; }
        [Required]
        public string Value { get; set; }
        public Type Type { get; set; } // Used for AutoMapper
        public string AssemblyQualifiedName { get; set; } // Used for AutoMapper

        public ValueEntityDto()
        {
        }

        public ValueEntityDto(string value, Type type, Guid id = new Guid())
        {
            Id = id;
            Value = value;
            Type = type;
        }
    }
}