using System;
namespace Recoveries
{
    public interface IQueueOptions
    {
        string HostName { get; }
        string VirtualHost { get; }
        string Username { get; }
        string Password { get; }
        string QueueName { get; }
        bool Purge { get; }
        int MaxNumberOfMessagesToRetrieve { get; }
        string MessageFilePath { get; }

        void SetQueueName(string name);
    }

    public class QueueOptions : IQueueOptions
    {
        //public QueueOptions()
        //{
        //    QueueName = "EasyNetQ_Default_Error_Queue";
        //    HostName = "localhost";
        //    VirtualHost = "/";
        //    Username = "guest";
        //    Password = "guest";
        //    Purge = false;
        //    MaxNumberOfMessagesToRetrieve = 1000;
        //    MessageFilePath = Environment.CurrentDirectory;
        //  //  Commands = new[] {QueueCommand.Dump, QueueCommand.Insert, QueueCommand.Error, QueueCommand.Retry, QueueCommand.Print};
        //}

        public QueueOptions(string queueName, string hostname, string vHost, string username, string password, bool purge,
            int numberOfMessagesToRetrieve,
            string messageFilePath //, QueueCommand[] commands
            )
        {
            QueueName = queueName;
            HostName = hostname;
            VirtualHost = vHost;
            Username = username;
            Password = password;
            Purge = purge;
            MaxNumberOfMessagesToRetrieve = numberOfMessagesToRetrieve;
            MessageFilePath = messageFilePath;
           // Commands = commands;
        }


        public void SetQueueName(string name)
        {
            QueueName = name;
        }

        public string HostName { get; private set; }
        public string VirtualHost { get; private set; }
        public string Username { get; private set; }
        public string Password { get; private set; }
        public string QueueName { get; private set; }
        public bool Purge { get; private set; }
        public int MaxNumberOfMessagesToRetrieve { get; private set; }
        public string MessageFilePath { get; private set; }
        //  public QueueCommand[] Commands { get; private set; }
    }
}