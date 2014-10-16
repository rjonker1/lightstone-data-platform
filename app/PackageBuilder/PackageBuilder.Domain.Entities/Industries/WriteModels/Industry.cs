using System;

namespace PackageBuilder.Domain.Entities.Industries.WriteModels
{
    public class Industry
    {
        public Guid Id { get; private set; }
        public string Name { get; set; }

        public Industry(Guid id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}