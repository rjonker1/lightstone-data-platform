using System;

namespace Workflow.Lace.Repository
{
    public interface IRepository
    {
        T Get<T>(Guid id) where T : class;
        void Add<T>(T instance);
    }
}
