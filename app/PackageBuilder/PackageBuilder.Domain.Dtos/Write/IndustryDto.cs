using System;

namespace PackageBuilder.Domain.Dtos.Write
{
    public class IndustryDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public bool IsSelected { get; set; }
    }
}