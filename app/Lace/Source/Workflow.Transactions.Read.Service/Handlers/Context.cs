using NServiceBus;
using Workflow.Lace.Messages.Events;

namespace Workflow.Transactions.Read.Service.Handlers
{
    public class Context : IHandleMessages<SecurityFlagRaised>, IHandleMessages<DataProviderConfigured>,
        IHandleMessages<DataProviderResponseTransformed>, IHandleMessages<DataProviderError>,
        IHandleMessages<DataProviderCallStarted>, IHandleMessages<DataProviderCallEnded>
    {
        public void Handle(SecurityFlagRaised message)
        {
            
        }

        public void Handle(DataProviderConfigured message)
        {
           
        }

        public void Handle(DataProviderCallEnded message)
        {
            
        }

        public void Handle(DataProviderCallStarted message)
        {
           
        }

        public void Handle(DataProviderError message)
        {
            
        }

        public void Handle(DataProviderResponseTransformed message)
        {
          
        }
    }
}
