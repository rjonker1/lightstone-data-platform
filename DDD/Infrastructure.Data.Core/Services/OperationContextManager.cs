using System;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using Topics.Radical;
using Topics.Radical.Validation;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    internal class OperationContextManager : IOperationContextManager
    {
        private readonly IServiceProvider container;

        public OperationContextManager(IServiceProvider container)
        {
            Ensure.That(container).Named(() => container).IsNotNull();

            this.container = container;
        }

        public IOperationContext GetCurrent()
        {
            return container.GetService<IOperationContext>();
        }
    }
}