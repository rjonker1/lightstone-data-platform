using System;
using Shared.BuildingBlocks.AdoNet.Mapping;

namespace Shared.BuildingBlocks.AdoNet.Repository
{
    public interface IRepositoryMapper
    {
        TypeMapper GetMapping(Type type);
        TypeMapper GetMapping<TType>(TType instance);
    }
}
