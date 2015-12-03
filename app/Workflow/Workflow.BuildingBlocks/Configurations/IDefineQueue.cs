using System.Configuration;

namespace Workflow.BuildingBlocks.Configurations
{
    public interface IDefineQueue
    {
        string ConnectionStringKey { get; }
        //string QueueName { get; }
        string ExchangeName { get; }
        string ErrorExchangeName { get; }
        string ErrorQueueName { get; }
        string ExchangeType { get; }
    }

    public class QueueDefinition : IDefineQueue
    {
        public string ConnectionStringKey
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings["workflow/connectionstring/key"]) 
                    ? ConfigurationManager.AppSettings["workflow/connectionstring/key"] 
                    : "workflow/bus/host";
            }
        }

        public string ExchangeName
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings["workflow/bus/exchangeName"])
                    ? ConfigurationManager.AppSettings["workflow/bus/exchangeName"]
                    : "workflow-bus";
            }
        }

        public string ErrorExchangeName
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings["workflow/bus/errorExchangeName"])
                    ? ConfigurationManager.AppSettings["workflow/bus/errorExchangeName"]
                    : "workflow-bus-errors";
            }
        }

        public string ErrorQueueName
        {
            get
            {
                return !string.IsNullOrEmpty(ConfigurationManager.AppSettings["workflow/bus/errorQueueName"])
                    ? ConfigurationManager.AppSettings["workflow/bus/errorQueueName"]
                    : "workflow-bus-errors";
            }
        }

        public string ExchangeType
        {
            get
            {
                return ConfigurationManager.AppSettings["workflow/connectionstring/exchangeType"];
            }
        }
    }
}
