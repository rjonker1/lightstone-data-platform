using System;
using System.Configuration;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Discovery;
using LightstoneApp.Presentation.Windows.WPF.ServiceAgents.Proxies.MainModule;

namespace LightstoneApp.Presentation.Windows.WPF.ServiceAgents
{
    /// <summary>
    ///     Proxy Locator
    /// </summary>
    public static class ProxyLocator
    {
        /// <summary>
        ///     Create new instance of
        ///     <see
        ///         cref="LightstoneApp.Presentation.Windows.WPF.ServiceAgents.Proxies.LightstoneApp.Presentation.Windows.WPF.ServiceAgents.Proxies.MainModule.IMainModuleService" />
        ///     instance with a configuration of uri, via behaviors, etc
        /// </summary>
        /// <returns>
        ///     New instance of
        ///     <see
        ///         cref="LightstoneApp.Presentation.Windows.WPF.ServiceAgents.Proxies.LightstoneApp.Presentation.Windows.WPF.ServiceAgents.Proxies.MainModule.IMainModuleService" />
        /// </returns>
        public static IMainModuleService GetMainModuleService()
        {
            //This method encapsulate discover end point, set via behaviors, security credentials initialization
            //and other configuration params

            //if discovery services is enabled in configuration file
            string discoveryValue = ConfigurationManager.AppSettings["discovery_wcf_services"];
            bool discoveryResult;

            if (!string.IsNullOrEmpty(discoveryValue)
                &&
                !string.IsNullOrWhiteSpace(discoveryValue)
                &&
                Boolean.TryParse(discoveryValue, out discoveryResult)
                &&
                discoveryResult)
            {
                //for more information about DynamicEndpoint and WS-Discovery see
                //http://msdn.microsoft.com/en-us/library/dd288697.aspx
                //http://geeks.ms/blogs/unai/archive/2009/12/21/wcf-4-0-ws-discovery-y-dynamicendpoint.aspx

                var endpoint = new DynamicEndpoint(ContractDescription.GetContract(typeof (IMainModuleService)),
                    new WS2007HttpBinding());


                return new MainModuleServiceClient(endpoint);
            }
            return new MainModuleServiceClient();
        }
    }
}