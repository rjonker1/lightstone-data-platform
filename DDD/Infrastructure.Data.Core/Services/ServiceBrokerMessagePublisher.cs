using System.Data.SqlClient;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework;
using LightstoneApp.Infrastructure.Data.Core.Events;
using Raven.Imports.Newtonsoft.Json;

namespace LightstoneApp.Infrastructure.Data.Core.Services
{
    public class ServiceBrokerMessagePublisher : IMessagePublisher
    {
        private readonly string ConnectionString = @"Data Source=.\SQLExpress;Initial Catalog=ServiceBrokerTest;Persist Security Info=True;User ID=sa";
        private readonly string MessageType = "SBMessage";
        private readonly string Contract = "SBContract";
        private readonly string SchedulerService = "SchedulerService";
        private readonly string NotifierService = "NotifierService";

        public void Publish(IApplicationEvent applicationEvent)
        {
            using (var sqlConnection = new SqlConnection(ConnectionString))
            {
                sqlConnection.Open();
                using (var sqlTransaction = sqlConnection.BeginTransaction())
                {
                    var conversationHandle = ServiceBrokerWrapper.BeginConversation(sqlTransaction, SchedulerService, NotifierService, Contract);

                    string json = JsonConvert.SerializeObject(applicationEvent, Formatting.None);

                    ServiceBrokerWrapper.Send(sqlTransaction, conversationHandle, MessageType, ServiceBrokerWrapper.GetBytes(json));

                    ServiceBrokerWrapper.EndConversation(sqlTransaction, conversationHandle);

                    sqlTransaction.Commit();
                }
                sqlConnection.Close();
            }
        }
    }
}
