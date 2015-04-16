using System;
namespace Shared.BuildingBlocks.AdoNet.Repository
{
    public interface IRepository
    {
        TType Get<TType>(Guid id) where TType : class;
        void Add<TType>(TType instance);
    }
}