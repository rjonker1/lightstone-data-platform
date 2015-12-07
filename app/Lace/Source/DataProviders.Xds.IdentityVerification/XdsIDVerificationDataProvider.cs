﻿using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Enums;
using DataProviders.Xds.IdentityVerification.Infrastructure;
using Lace.Domain.Core.Contracts.DataProviders;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Consumer;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.Core.Extensions;
using Lace.Domain.DataProviders.Core.Shared;
using Workflow.Lace.Messages.Core;

namespace DataProviders.Xds.IdentityVerification
{
    public class XdsIdentityVerificationDataProvider : ExecuteSourceBase, IExecuteTheDataProviderSource
    {
        private readonly ICollection<IPointToLaceRequest> _request;
        private readonly ISendCommandToBus _command;
        private ILogCommandTypes _logCommand;
        private IAmDataProvider _dataProvider;

        public XdsIdentityVerificationDataProvider(ICollection<IPointToLaceRequest> request, IExecuteTheDataProviderSource nextSource, IExecuteTheDataProviderSource fallbackSource, ISendCommandToBus command)
            : base(nextSource, fallbackSource)
        {
            _request = request;
            _command = command;
        }

        public void CallSource(ICollection<IPointToLaceProvider> response)
        {
            var spec = new CanHandlePackageSpecification(DataProviderName.XDSVerifyID_E_WS, _request);

            if (!spec.IsSatisfied)
            {
                NotHandledResponse(response);
            }
            else
            {
                _dataProvider = _request.First().Package.DataProviders.Single(w => w.Name == DataProviderName.XDSVerifyID_E_WS);
                _logCommand = LogCommandTypes.ForDataProvider(_command, DataProviderCommandSource.XDSVerifyID_E_WS, _dataProvider, _dataProvider.BillablleState.NoRecordState);

                _logCommand.LogBegin(new {_dataProvider});

                var consumer = new ConsumeSource(new HandleXdsIdVerificationCall(), new CallXdsDataProvider(_dataProvider, _logCommand));

                consumer.ConsumeDataProvider(response);

                _logCommand.LogEnd(new {response});

                if (!response.HasRecords<IProvideDataFromXdsIdentityVerification>()) CallFallbackSource(response, _command);
            }

            CallNextSource(response, _command);
        }

        private static void NotHandledResponse(ICollection<IPointToLaceProvider> response)
        {
            var xdsResponse = XdsIdentityVerificationResponse.Empty();
            xdsResponse.HasNotBeenHandled();
            response.Add(xdsResponse);
        }
    }
}