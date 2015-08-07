using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using EasyNetQ;
using Recoveries.Core;
using Recoveries.ErrorQueues;

namespace Recoveries.Router
{
    public interface IHandleErrorMessageRecovery
    {
        void Handle(IQueueOptions options);

        void HandleAll(IErrorQueueConfiguration[] configurations);
    }

    public class ErrorMessageRecoveryHandler : IHandleErrorMessageRecovery
    {
        private readonly ILog _log = LogManager.GetLogger<RecoveryService>();

        private readonly IQueueRetrieval _queueRetreival;
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;
        private readonly IErrorRetry _errorRetry;
        private readonly IDeleteFiles _errorDelete;
        private readonly IPurgeQueue _errorPurge;

        public ErrorMessageRecoveryHandler()
        {
        }

        private ErrorMessageRecoveryHandler(
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

        public static ErrorMessageRecoveryHandler Create()
        {
            var typeNameSerializer = new TypeNameSerializer();

            var handler = new ErrorMessageRecoveryHandler(
                new QueueRetrieval(),
                new FileMessageWriter(),
                new MessageReader(),
                new ErrorRetry(new JsonSerializer(typeNameSerializer)),
                new DeleteErrorFiles(),
                new PurgeErrorQueue());

            return handler;
        }

        public void Handle(IQueueOptions options)
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
            catch (EasyNetQException ex)
            {
                _log.ErrorFormat("Operation Failed in Recovery Service because of {0}", ex, ex.Message);
            }


            if (succeeded)
                return;

            _log.Error("Operation failed");
            _log.Error(results.ToString());
        }

        public void HandleAll(IErrorQueueConfiguration[] configurations)
        {
            foreach (var configuration in ConfigurationReader.Configurations)
            {
                Handle(configuration.Options);
            }
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
            var files = WithEach(_errorDelete.DeleteMessages(options), () => count++).ToList();
            _log.InfoFormat("{0}/{2} Error messages from directory '{1}' have been deleted", count, options.MessageFilePath, files.Any() ? files.Max() : 0);
        }

        private void Purge(IQueueOptions options)
        {
            var count = 0;
            var messages = WithEach(_errorPurge.PurgeQueue(options), () => count++).ToList();
            _log.InfoFormat("{0}/{2} messages from Queue '{1}' have been Purged", count, options.ErrorQueueName, messages.Any() ? messages.Max() : 0);

        }

        private static IEnumerable<RecoveryMessage> WithEach(IEnumerable<RecoveryMessage> messages, Action action)
        {
            foreach (var message in messages)
            {
                action();
                yield return message;
            }
        }

        private static IEnumerable<int> WithEach(IEnumerable<int> counts, Action action)
        {
            foreach (var count in counts)
            {
                action();
                yield return count;
            }
        }

        private static IEnumerable<uint> WithEach(IEnumerable<uint> counts, Action action)
        {
            foreach (var count in counts)
            {
                action();
                yield return count;
            }
        }
    }
}
