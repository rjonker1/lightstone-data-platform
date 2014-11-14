using System;

namespace PackageBuilder.Domain.Entities
{
    public interface IExpirable
    {
        DateTime ValidUntil { get; }
    }
}