using System;

namespace DataPlatform.Shared.Public.Entities
{
    public interface IExpirable
    {
        DateTime ValidUntil { get; set; }
    }
}