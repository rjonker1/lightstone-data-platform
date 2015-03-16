using System;
using System.Collections.Generic;

namespace Workflow.Billing.Repository
{
    public interface IHaveTypeMappings
    {
        Dictionary<Type, TypeMapper> Mappings { get; }
    }
}
