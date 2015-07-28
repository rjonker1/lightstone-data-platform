using System;
using System.Collections.Generic;
using System.Text;
using Common.Logging;
using EasyNetQ;
using Recoveries.ErrorQueues;

namespace Recoveries.Router
{
    public interface IRecoveryService
    {
        //void Start(IQueueOptions parameters);
        void Start();
        void Stop();
    }

    public class RecoveryService : IRecoveryService
    {
        private readonly ILog _log = LogManager.GetLogger<RecoveryService>();

       // private readonly ArgumentParser _argumentParser;
        private readonly IQueueRetrieval _queueRetreival;
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;
        private readonly IQueueInsertion _queueInsertion;
        private readonly IErrorRetry _errorRetry;
        private readonly IConventions _conventions;

        public RecoveryService()
        {
        }

        private RecoveryService(
           // ArgumentParser argumentParser,
            IQueueRetrieval queueRetreival,
            IMessageWriter messageWriter,
            IMessageReader messageReader,
            IQueueInsertion queueInsertion,
            IErrorRetry errorRetry,
            IConventions conventions)
        {
            // _argumentParser = argumentParser;
            _queueRetreival = queueRetreival;
            _messageWriter = messageWriter;
            _messageReader = messageReader;
            _queueInsertion = queueInsertion;
            _errorRetry = errorRetry;
            _conventions = conventions;
        }

        public void Start()
        {
            var typeNameSerializer = new TypeNameSerializer();

            var service = new RecoveryService(
                //new ArgumentParser(),
                new QueueRetrieval(),
                new FileMessageWriter(),
                new MessageReader(),
                new QueueInsertion(),
                new ErrorRetry(new JsonSerializer(typeNameSerializer)),
                new Conventions(typeNameSerializer));

            foreach (var configuration in ConfigurationReader.Configurations)
            {
                service.Run(configuration.Options);
            }
        }

        private void Run(IQueueOptions options)
        {
           // var arguments = _argumentParser.Parse(options);

            var results = new StringBuilder();
            var succeeded = true;
            Func<string, Action> messsage = m => () =>
            {
                results.AppendLine(m);
                succeeded = false;
            };

            //var parameters = new QueueParameters();
            //arguments.WithKey(RecoveryQueueOption.HostName, a => options.HostName = a.Value);
            //arguments.WithKey("v", a => options.VirtualHost = a.Value);
            //arguments.WithKey("u", a => options.Username = a.Value);
            //arguments.WithKey("p", a => options.Password = a.Value);
            //arguments.WithKey("o", a => options.MessageFilePath = a.Value);
            //arguments.WithTypedKeyOptional<int>("n", a => options.MaxNumberOfMessagesToRetrieve = int.Parse(a.Value))
            //    .FailWith(messsage("Invalid number of messages to retrieve"));
            //arguments.WithTypedKeyOptional<bool>("x", a => options.Purge = bool.Parse(a.Value))
            //    .FailWith(messsage("Invalid purge (x) parameter"));

            try
            {
               // Dump(options);
               // Insert(options);
               //ErrorDump(options);
               Retry(options);

                //arguments.At(0, "dump", () => arguments.WithKey("q", a =>
                //{
                //    options.QueueName = a.Value;
                //    Dump(options);
                //}).FailWith(messsage("No Queue Name given")));

                //arguments.At(0, "insert", () => Insert(options));

                //arguments.At(0, "err", () => ErrorDump(options));

                //arguments.At(0, "retry", () => Retry(options));

               
            }
            catch (EasyNetQHosepipeException ex)
            {
                _log.ErrorFormat("Operation Failed in Recovery Service because of {0}", ex, ex.Message);
            }


            if(succeeded)
                return;

            _log.Error("Operation failed");
            _log.Error(results.ToString());
        }

        private void Dump(IQueueOptions options)
        {
            var count = 0;
            _messageWriter.Write(WithEach(_queueRetreival.GetMessagesFromQueue(options), () => count++), options);

            _log.InfoFormat("{0} Messages from queue '{1}'\r\noutput to directory '{2}'",
                count, options.ErrorQueueName, options.MessageFilePath);
        }

        private void Insert(IQueueOptions options)
        {
            var count = 0;
            _queueInsertion.PublishMessagesToQueue(
                WithEach(_messageReader.ReadMessages(options), () => count++), options);

            _log.InfoFormat("{0} Messages from directory '{1}'\r\ninserted into queue '{2}'",
                count, options.MessageFilePath, options.QueueName);
        }

        private void ErrorDump(IQueueOptions options)
        {
           // options.SetQueueName(_conventions.ErrorQueueNamingConvention()); // options.QueueName = _conventions.ErrorQueueNamingConvention();
            Dump(options);
        }

        private void Retry(IQueueOptions options)
        {
            var count = 0;
            //_errorRetry.RetryErrors(
            //    WithEach(
            //        _messageReader.ReadMessages(options, _conventions.ErrorQueueNamingConvention()),
            //        () => count++),
            //    options);
            _errorRetry.RetryErrors(
               WithEach(
                   _messageReader.ReadMessages(options, options.ErrorQueueName),
                   () => count++),
               options);

            _log.InfoFormat("{0} Error messages from directory '{1}' republished",
                count, options.MessageFilePath);
        }

        private static IEnumerable<HosepipeMessage> WithEach(IEnumerable<HosepipeMessage> messages, Action action)
        {
            foreach (var message in messages)
            {
                action();
                yield return message;
            }
        }

        public void Stop()
        {
            
        }
    }
}
