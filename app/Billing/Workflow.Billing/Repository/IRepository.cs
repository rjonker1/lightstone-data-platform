using System;

namespace Workflow.Billing.Repository
{
    public interface IRepository
    {
        TType Get<TType>(Guid id) where TType : class;
        void Add<TType>(TType instance);
    }
}