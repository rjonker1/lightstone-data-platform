using System;
using System.Collections.Generic;
using Common.Logging;
using Lace.Domain.Core.Contracts.Requests;
using Lace.Domain.Core.Entities;
using Lace.Domain.Core.Requests.Contracts;
using Lace.Domain.DataProviders.Core.Contracts;
using Lace.Domain.DataProviders.PCubed.Infrastructure.Management;

namespace Lace.Domain.DataProviders.PCubed.Infrastructure
{
    public class CallPCubedDataProvider : ICallTheDataProviderSource
    {
        private readonly ILog _log;
        private readonly IAmDataProvider _dataProvider;
        private readonly ILogComandTypes _logComand;
       
        private string _response;

        public CallPCubedDataProvider(IAmDataProvider dataProvider, ILogComandTypes logComand)
        {
            _log = LogManager.GetLogger(GetType());
            _dataProvider = dataProvider;
            _logComand = logComand;
        }

        public void CallTheDataProvider(ICollection<IPointToLaceProvider> response)
        {
            try
            {
                //command.Monitoring.Send(CommandType.Configuration,
                //    new
                //    {
                //        Configuration =
                //            new
                //            {
                //                _client.Url,
                //                _client.Username,
                //                _client.Password,
                //                _client.XAuthToken,
                //                _client.Operation
                //            }
                //    },
                //    new { ContextMessage = "PCubed Fica Data Provider Configuration" });

                //command.Monitoring.StartCall(_client.Operation, _stopWatch);

                //_client.Run();

                //command.Monitoring.EndCall(_client.IsSuccessful ? _client.Resonse : "No Response Returned", _stopWatch);

                _response = string.Empty;


                if (string.IsNullOrWhiteSpace(_response))
                    _logComand.LogFault(_dataProvider, new { NoRequestReceived = "No response received from PCubed Fica Service" });

                TransformResponse(response);
            }
            catch (Exception ex)
            {
                _log.ErrorFormat("Error calling PCubed Fica Data Provider {0}", ex.Message);
                _logComand.LogFault(ex.Message, new { ErrorMessage = "Error calling PCubed Fica Data Provider" });
                SignioResponseFailed(response);
            }
        }

        private static void SignioResponseFailed(ICollection<IPointToLaceProvider> response)
        {
            var ficaVerficationResponse = new PCubedFicaVerficationResponse();
            ficaVerficationResponse.HasNotBeenHandled();
            response.Add(ficaVerficationResponse);
        }

        public void TransformResponse(ICollection<IPointToLaceProvider> response)
        {
            var transformer = new TransformPCubedResponse(_response);

            if (transformer.Continue)
            {
                transformer.Transform();
            }

            _logComand.LogTransformation(transformer.Result, null);

            transformer.Result.HasBeenHandled();
            response.Add(transformer.Result);
        }
    }
}
