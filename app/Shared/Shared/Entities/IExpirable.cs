using System;

namespace DataPlatform.Shared.Entities
{
    public interface IExpirable
    {
        DateTime ValidUntil { get; set; }
    }
}