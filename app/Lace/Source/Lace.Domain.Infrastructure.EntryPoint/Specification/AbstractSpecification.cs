using System;
using System.Collections.Generic;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public interface IExecuteSpecification
    {
        Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Execute();
    }

    public abstract class AbstractSpecificationExecutor
    {
        private readonly IExecuteSpecification _next;

        protected AbstractSpecificationExecutor(IExecuteSpecification next)
        {
            _next = next;
        }

        public Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> ExecuteNext()
        {
            return _next.Execute();
        }
    }
}