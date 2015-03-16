using System;
namespace Workflow.Billing.Repository
{
    public interface IRepositoryMapper
    {
        TypeMapper GetMapping(Type type);
        TypeMapper GetMapping<TType>(TType instance);
    }
}
