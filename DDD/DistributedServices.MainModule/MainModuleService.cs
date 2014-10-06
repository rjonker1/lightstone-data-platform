using System.ServiceModel;
using LightstoneApp.DistributedServices.Core.ErrorHandlers;

namespace LightstoneApp.DistributedServices.MainModule
{
    /// <summary>
    ///     Service facade for MainModule
    /// </summary>
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single,
        ConcurrencyMode = ConcurrencyMode.Multiple,
        Namespace = "LightstoneApp.DistributedServices.MainModule")]
    [ErrorHandlerServiceBehavior]
    public sealed partial class MainModuleService
        : IMainModuleService
    {
    }
}