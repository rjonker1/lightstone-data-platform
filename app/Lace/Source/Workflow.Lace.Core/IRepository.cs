using System;
namespace Workflow.Lace.Core
{
    public interface IRepository
    {
        TType Get<TType>(Guid id) where TType : class;
        void Add<TType>(TType instance);
    }
}
