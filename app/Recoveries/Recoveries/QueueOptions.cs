namespace Recoveries
{
    public interface IQueueOptions
    {
        string HostName { get; }
        string VirtualHost { get; }
        string Username { get; }
        string Password { get; }
        string QueueName { get; }
        string ErrorQueueName { get; }
        bool RequireHandshake { get; }
        int MaxNumberOfMessagesToRetrieve { get; }
        string MessageFilePath { get; }
    }

    public class QueueOptions : IQueueOptions
    {
        public QueueOptions(string queueName, string hostname, string virturalHost, string username, string password, bool needHandshake,
            int numberOfMessagesToRetrieve,
            string messageFilePath, string errorQueueName)
        {
            QueueName = queueName;
            HostName = hostname;
            VirtualHost = virturalHost;
            Username = username;
            Password = password;
            RequireHandshake = needHandshake;
            MaxNumberOfMessagesToRetrieve = numberOfMessagesToRetrieve;
            MessageFilePath = messageFilePath;
            ErrorQueueName = errorQueueName;
        }

        public string HostName { get; private set; }
        public string VirtualHost { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string QueueName { get; private set; }
        public bool RequireHandshake { get; private set; }
        public int MaxNumberOfMessagesToRetrieve { get; private set; }
        public string MessageFilePath { get; private set; }
        public string ErrorQueueName { get; private set; }
    }
}