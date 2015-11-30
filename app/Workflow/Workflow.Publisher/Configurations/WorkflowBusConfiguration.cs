namespace Workflow.Publisher.Configurations
{
    public class WorkflowBusConfiguration : AbstractConfigurationReader, IDefineBusEnvironment
    {
        public string ServiceName
        {
            get
            {
                return ConfigurationReader.Environment.AppendEnvironment(ReadAppSettings("workflow/bus/serviceName", "Workflow.Bus"));
            }
        }

        public string DisplayName
        {
            get
            {
                return ConfigurationReader.Environment.AppendEnvironment(ReadAppSettings("workflow/bus/serviceDisplayName", "Workflow.Bus"));
            }
        }

        public string ServiceDescription
        {
            get
            {
                return ConfigurationReader.Environment.AppendEnvironment(ReadAppSettings("workflow/bus/serviceDescription", "Workflow.Bus"));
            }
        }

        public string Host
        {
            get { return ReadConnectionString("workflow/bus/host", "host=localhost"); }
        }

        public string ExchangeName
        {
            get
            {
                return ConfigurationReader.Environment.AppendEnvironment(ReadAppSettings("workflow/bus/exchangeName", "workflow-bus"));
            }
        }

        public string ErrorExchangeName
        {
            get
            {
                return ConfigurationReader.Environment.AppendEnvironment(ReadAppSettings("workflow/bus/errorExchangeName", "workflow-bus-errors"));
            }
        }

        public string ErrorQueueName
        {
            get
            {
                return ConfigurationReader.Environment.AppendEnvironment(ReadAppSettings("workflow/bus/errorQueueName", "workflow-bus-errors"));
            }
        }
    }
}