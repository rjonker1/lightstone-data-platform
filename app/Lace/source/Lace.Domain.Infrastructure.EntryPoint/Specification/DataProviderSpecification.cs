using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using EasyNetQ;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.Lightstone.Property;
using Lace.Domain.DataProviders.PCubed;
using Lace.Domain.DataProviders.Rgt;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Domain.DataProviders.Signio.DriversLicense;
using Workflow.Lace.Messages.Shared;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class DataProviderSpecification
    {
        public static readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
            Chain =
                () =>
                    (request, bus, response, requestId) =>
                        new IvidDataProvider(request,
                            new LightstoneAutoDataProvider(request,
                                new IvidTitleHolderDataProvider(request,
                                    new RgtVinDataProvider(request,
                                        new RgtDataProvider(request,
                                            new SignioDataProvider(request, 
                                                new LightstonePropertyDataProvider(request, null, null,
                                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneProperty)), null,
                                                CommandSender.InitCommandSender(bus, requestId,DataProviderCommandSource.SignioDecryptDriversLicense)), null,
                                            CommandSender.InitCommandSender(bus, requestId,DataProviderCommandSource.Rgt)), null,
                                        CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.RgtVin)),null,
                                    CommandSender.InitCommandSender(bus, requestId,DataProviderCommandSource.IvidTitleHolder)), null,
                                CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneAuto)),null,
                            CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.Ivid))
                            .CallSource(response);


        private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
          _ficaRequestSpecification =
              () =>
                  (request, bus, response, requestId) =>
                      new PCubedDataProvider(request, null, null,
                          CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.PCubedFica))
                          .CallSource(response);

        //public static Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid> Builder
        //{
        //    get
        //    {
        //        return Chain();
        //    }
        //}
        
        
        //private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
        //    _driversLicenseDecryptionRequestSpecification =
        //        () =>
        //            (request, bus, response, requestId) =>
        //                new SignioDataProvider(request, null, null,
        //                    CommandSender.InitCommandSender(bus, requestId,
        //                        DataProviderCommandSource.SignioDecryptDriversLicense)).CallSource(response);

        //private readonly Func<Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>
        //    _propertyRequestSpecification =
        //        () =>
        //            (request, bus, response, requestId) =>
        //                new LightstonePropertyDataProvider(request, null, null,
        //                    CommandSender.InitCommandSender(bus, requestId, DataProviderCommandSource.LightstoneProperty))
        //                    .CallSource(
        //                        response);

      

        //public IEnumerable<KeyValuePair<int, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>>
        //    Specifications
        //{
        //    get
        //    {
        //        return new Dictionary<int, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>()
        //        {
        //            {
        //                0, _specification()
        //            }
        //        };
        //    }
        //}

        //public
        //    IEnumerable
        //        <
        //            KeyValuePair
        //                <string, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>
        //                    >>
        //    Specifications
        //{
        //    get
        //    {
        //        return new Dictionary
        //            <string, Action<ICollection<IPointToLaceRequest>, IAdvancedBus, ICollection<IPointToLaceProvider>, Guid>>()
        //        {
        //            {
        //                "License plate search", _Specification()
        //            },
        //            {
        //                "License Scan", _driversLicenseDecryptionRequestSpecification()
        //            },
        //            {
        //                "Fica", _ficaRequestSpecification()
        //            },
        //            {
        //                "Property Search", _propertyRequestSpecification()
        //            }
        //        };
        //    }
        //}
    }
}
