using System;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;
using LightstoneApp.DistributedServices.Core.Resources;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Logging;

namespace LightstoneApp.DistributedServices.Core.ErrorHandlers
{
    /// <summary>
    /// Default error handler for WCF Service Facade
    /// </summary>
    public sealed class ApplicationErrorHandler : IErrorHandler
    {
        #region IErrorHandler

        public bool HandleError(Exception error)
        {
            if (error != null)
                LoggerFactory.CreateLog().Error(Messages.error_unmanagederror, error);

            //set  error as handled 
            return true;
        }

        public void ProvideFault(Exception error, MessageVersion version, ref Message fault)
        {
            var exception = error as FaultException<ApplicationServiceError>;
            if (exception != null)
            {
                var messageFault = exception.CreateMessageFault();
                //propagate FaultException
                fault = Message.CreateMessage(version, messageFault,exception.Action);
            }
            else
            {
                //create service error
                var defaultError = new ApplicationServiceError
                    {
                        ErrorMessage = Messages.message_DefaultErrorMessage
                    };

                //Create fault exception and message fault
                var defaultFaultException = new FaultException<ApplicationServiceError>(defaultError);
                var defaultMessageFault = defaultFaultException.CreateMessageFault();

                //propagate FaultException
                fault = Message.CreateMessage(version, defaultMessageFault, defaultFaultException.Action);
            }
        }

        #endregion
    }
}