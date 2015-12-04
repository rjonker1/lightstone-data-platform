using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using DataPlatform.Shared.Enums;
using DataProviders.Xds.IdentityVerification.Infrastructure.Configuration;
using DataProviders.Xds.IdentityVerification.Infrastructure.Dto;
using DataProviders.Xds.IdentityVerification.Infrastructure.Management;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Shared.Extensions;
using PackageBuilder.Domain.Requests.Contracts.Requests;
using Workflow.Lace.Identifiers;

namespace DataProviders.Xds.IdentityVerification.Infrastructure
{
    public class CallXdsDataProvider : ICallTheDataProviderSource
    {
        private static readonly ILog Log = LogManager.GetLogger<CallXdsDataProvider>();
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogCommandTypes _logCommand;
        private ListOfConsumers _result;

        public CallXdsDataProvider(IAmDataProvider dataProvider, ILogCommandTypes logCommand)
        {
            _dataProvider = dataProvider;
            _logCommand = logCommand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                var api = new ConfigureApi();
                if (string.IsNullOrEmpty(api.Ticket))
                    throw new Exception("Cannot continue calling XDS Api. User is not valid");

                _logCommand.LogSecurity(new { Credentials = new { api.Username, api.Password } },
                    new { Message = "XDS Data Provider Credentials" });


                var request = new IdentityVerificationRequest(_dataProvider.GetRequest<IAmXdsIdentificationVerificationRequest>()).Map().Validate();

                _logCommand.LogRequest(new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(),
                    new { _dataProvider }, _dataProvider.BillablleState.NoRecordState, string.Empty);

                _result = api.Client.ConnectIDVerification(api.Ticket, request.IdNumber, request.FirstName, request.Surname,
                    request.ReferenceNumber, request.VoucherCode).XmlToObject<ListOfConsumers>();

                _logCommand.LogResponse(_result == null || _result.ConsumerDetails == null ? DataProviderResponseState.NoRecords : DataProviderResponseState.Successful,
                    new ConnectionTypeIdentifier(api.Client.Endpoint.Address.ToString()).ForWebApiType(), new { _result }, _dataProvider.BillablleState.NoRecordState, CheckReferenceNumber());

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("Error calling XDS ID Verification Data Provider {0}", ex, ex.Message);
                _logCommand.LogFault(ex, new { ErrorMessage = "Error calling XDS ID Verification Data Provider" });
                XdsResponseFailed(response);
            }
        }

        private static void XdsResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var xdsResponse = XdsIdentityVerificationResponse.WithState(DataProviderResponseState.TechnicalError);
            xdsResponse.HasBeenHandled();
            response.Add(xdsResponse);
        }
        

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformXdsResponse(_result);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logCommand.LogTransformation(transformer.Result ?? XdsIdentityVerificationResponse.Empty(), null);
            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }

        private string CheckReferenceNumber()
        {
            if (_result == null || _result.ConsumerDetails == null)
                return string.Empty;

            return _result.ConsumerDetails.Reference;

            //var referenceNumber = new StringBuilder();
            //_result.ConsumerDetails.ForEach(f => referenceNumber.AppendFormat("{0} |"));
            //return referenceNumber.ToString().TrimEnd('|');
        }
    }
}
