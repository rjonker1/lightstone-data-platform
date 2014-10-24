using LightstoneApp.Application.PackageBuilderModule.Dtos;
using LightstoneApp.DistributedServices.Core;
using System.ServiceModel;


namespace LightstoneApp.Services.PackageBuilderModule.WcfServices
{
    using System;
    using System.Collections.Generic;
    
    [ServiceContract(Name = "IDataProviderWcfService")]
    public partial interface IDataProviderWcfService : IWcfService<DataProvider> { }
}
