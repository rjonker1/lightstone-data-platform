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
        void Start();
        void Stop();
    }

    public class RecoveryService : IRecoveryService
    {
        private readonly ILog _log = LogManager.GetLogger<RecoveryService>();

        private readonly IQueueRetrieval _queueRetreival;
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;
        private readonly IErrorRetry _errorRetry;
        private readonly IDeleteFiles _errorDelete;
        private readonly IPurgeQueue _errorPurge;

        public RecoveryService()
        {
        }

        private RecoveryService(
            IQueueRetrieval queueRetreival,
            IMessageWriter messageWriter,
            IMessageReader messageReader,
            IErrorRetry errorRetry,
            IDeleteFiles errorDelete,
            IPurgeQueue errorPurge)
        {
            _queueRetreival = queueRetreival;
            _messageWriter = messageWriter;
            _messageReader = messageReader;
            _errorRetry = errorRetry;
            _errorDelete = errorDelete;
            _errorPurge = errorPurge;
        }

        public void Start()
        {
            var typeNameSerializer = new TypeNameSerializer();

            var service = new RecoveryService(
                new QueueRetrieval(),
                new FileMessageWriter(),
                new MessageReader(),
                new ErrorRetry(new JsonSerializer(typeNameSerializer)),
                new DeleteErrorFiles(),
                new PurgeErrorQueue());

            foreach (var configuration in ConfigurationReader.Configurations)
            {
                service.Run(configuration.Options);
            }
        }

        private void Run(IQueueOptions options)
        {
            var results = new StringBuilder();
            var succeeded = true;
            Func<string, Action> messsage = m => () =>
            {
                results.AppendLine(m);
                succeeded = false;
            };

            try
            {
                Delete(options);
                ErrorDump(options);
                Purge(options);
                Retry(options);
            }
            catch (EasyNetQHosepipeException ex)
            {
                _log.ErrorFormat("Operation Failed in Recovery Service because of {0}", ex, ex.Message);
            }


            if (succeeded)
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

        private void ErrorDump(IQueueOptions options)
        {
            Dump(options);
        }

        private void Retry(IQueueOptions options)
        {
            var count = 0;
            _errorRetry.RetryErrors(
                WithEach(
                    _messageReader.ReadMessages(options, options.ErrorQueueName),
                    () => count++),
                options);

            _log.InfoFormat("{0} Error messages from directory '{1}' republished",
                count, options.MessageFilePath);
        }

        private void Delete(IQueueOptions options)
        {
            var count = 0;
            WithEach(_errorDelete.DeleteMessages(options), () => count++);
            _log.InfoFormat("{0} Error messages from direcotry '{1}' have been deleted", count, options.MessageFilePath);
        }

        private void Purge(IQueueOptions options)
        {
            var count = 0;
            WithEach(_errorPurge.PurgeQueue(options), () => count++);
            _log.InfoFormat("{0} messages from Queue '{1}' have been Purged", count, options.ErrorQueueName);

        }

        private static IEnumerable<HosepipeMessage> WithEach(IEnumerable<HosepipeMessage> messages, Action action)
        {
            foreach (var message in messages)
            {
                action();
                yield return message;
            }
        }

        private static void WithEach(IEnumerable<int> counts, Action action)
        {
            action();
        }

        private static void WithEach(IEnumerable<uint> counts, Action action)
        {
            action();
        }

        public void Stop()
        {

        }
    }
}