using System.ServiceModel.Description;

namespace LightstoneApp.Presentation.Windows.WPF.ServiceAgents.Proxies.MainModule
{
    /// <summary>
    ///     MainModule service client proxy
    /// </summary>
    public partial class MainModuleServiceClient
    {
        /// <summary>
        ///     Constructor for use Dynamic Endpoint transparency
        ///     <remarks>
        ///         This constructor is created Adhoc not by svcutil
        ///     </remarks>
        /// </summary>
        /// <param name="endpoint">dynamic endpoint with criteria to discover this service</param>
        public MainModuleServiceClient(ServiceEndpoint endpoint)
            : base(endpoint)
        {
        }
    }
}