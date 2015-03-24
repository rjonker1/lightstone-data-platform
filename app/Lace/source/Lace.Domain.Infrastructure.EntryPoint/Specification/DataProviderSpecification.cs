using System;
using System.Collections.Generic;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Audatex;
using Lace.Domain.DataProviders.Ivid;
using Lace.Domain.DataProviders.IvidTitleHolder;
using Lace.Domain.DataProviders.Lightstone;
using Lace.Domain.DataProviders.Lightstone.Property;
using Lace.Domain.DataProviders.PCubed;
using Lace.Domain.DataProviders.Rgt;
using Lace.Domain.DataProviders.RgtVin;
using Lace.Domain.DataProviders.Signio.DriversLicense;
using Lace.Shared.Monitoring.Messages.Core;
using Lace.Shared.Monitoring.Messages.Shared;
using NServiceBus;

namespace Lace.Domain.Infrastructure.EntryPoint.Specification
{
    public class DataProviderSpecification
    {
        private readonly Func<Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _defaultLicenseNumberRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new IvidDataProvider(request,
                            new LightstoneDataProvider(request,
                                new IvidTitleHolderDataProvider(request,
                                    new RgtVinDataProvider(request,
                                        new RgtDataProvider(request,
                                            new AudatexDataProvider(request, null, null,
                                                new SendAudatexCommands(bus, requestId, (int) ExecutionOrder.Sixth)),
                                            null,
                                            new SendRgtCommands(bus, requestId, (int) ExecutionOrder.Fifth)), null,
                                        new SendRgtVinCommands(bus, requestId, (int) ExecutionOrder.Fourth)), null,
                                    new SendIvidTitleHolderCommands(bus, requestId, (int) ExecutionOrder.Third)), null,
                                new SendLightstoneCommands(bus, requestId, (int) ExecutionOrder.Second)), null,
                            new SendIvidCommands(bus, requestId, (int) ExecutionOrder.First))
                            .CallSource(response);



        private readonly Func<Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _driversLicenseDecryptionRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new SignioDataProvider(request, null, null,
                            new SendSignioCommands(bus, requestId, (int) ExecutionOrder.First)).CallSource(response);

        private readonly Func<Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _propertyRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new LightstonePropertyDataProvider(request, null, null,
                            new SendLightstonePropertyCommands(bus, requestId, (int) ExecutionOrder.First)).CallSource(response);

        // TODO: Lightstone Business


        private readonly Func<Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid>>
            _ficaRequestSpecification =
                () =>
                    (request, bus, response, requestId) =>
                        new PCubedDataProvider(request, null, null,
                            new SendPCubedCommands(bus, requestId, (int) ExecutionOrder.First)).CallSource(response);
        public
            IEnumerable
                <
                    KeyValuePair
                        <string, Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid>>>
            Specifications
        {
            get
            {
                return new Dictionary
                    <string, Action<ILaceRequest, IBus, ICollection<IPointToLaceProvider>, Guid>>()
                {
                    {
                        "License plate search", _defaultLicenseNumberRequestSpecification()
                    },
                    {
                        "License Scan", _driversLicenseDecryptionRequestSpecification()
                    },
                    {
                        "Fica", _ficaRequestSpecification()
                    },
                    {
                        "Property Search", _propertyRequestSpecification()
                    }
                };
            }
        }
    }
}
