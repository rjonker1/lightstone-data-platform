using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Common.Logging;
using Recoveries.Core;
using Recoveries.Domain.Base;
using Recoveries.Infrastructure.Configuration;

namespace Recoveries.Domain.Handlers
{
    public class ErrorMessageRecoveryHandler : IHandleErrorMessageRecovery
    {
        private static readonly ILog Log = LogManager.GetLogger<ErrorMessageRecoveryHandler>();

        private readonly IQueueRetrieval _queueRetreival;
        private readonly IMessageWriter _messageWriter;
        private readonly IMessageReader _messageReader;
        private readonly IErrorRetry _errorRetry;
        private readonly IDeleteFiles _errorDelete;
        private readonly IPurgeQueue _errorPurge;

        public ErrorMessageRecoveryHandler(
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
                Log.ErrorFormat("Operation Failed in Recovery Service because of {0}", ex, ex.Message);
            }


            if (succeeded)
                return;

            Log.Error("Operation failed");
            Log.Error(results.ToString());
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

            Log.InfoFormat("{0} Messages from queue '{1}'\r\noutput to directory '{2}'",
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

            Log.InfoFormat("{0} Error messages from directory '{1}' republished",
                count, options.MessageFilePath);
        }

        private void Delete(IQueueOptions options)
        {
            var count = 0;
            var files = WithEach(_errorDelete.DeleteMessages(options), () => count++).ToList();
            Log.InfoFormat("{0}/{2} Error messages from directory '{1}' have been deleted", count, options.MessageFilePath, files.Any() ? files.Max() : 0);
        }

        private void Purge(IQueueOptions options)
        {
            var count = 0;
            var messages = WithEach(_errorPurge.PurgeQueue(options), () => count++).ToList();
            Log.InfoFormat("{0}/{2} messages from Queue '{1}' have been Purged", count, options.ErrorQueueName, messages.Any() ? messages.Max() : 0);

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
