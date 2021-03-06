﻿using System.Collections.Generic;
using System.IO;
using Common.Logging;
using EasyNetQ;
using Recoveries.Core;
using Recoveries.Domain.Base;
using Recoveries.Shared;

namespace Recoveries
{
    public class MessageReader : IMessageReader
    {
        private static readonly ILog Log = LogManager.GetLogger<MessageReader>();
        public IEnumerable<RecoveryMessage> ReadMessages(IQueueOptions options)
        {
            return ReadMessages(options, null);
        }

        public IEnumerable<RecoveryMessage> ReadMessages(IQueueOptions options, string messageName)
        {
            if (!Directory.Exists(options.MessageFilePath))
            {
                Log.ErrorFormat("Directory '{0}' does not exist", options.MessageFilePath);
                Log.InfoFormat("Creating Directory at '{0}'", options.MessageFilePath);
                options.MessageFilePath.CreateDirectory();
                Log.InfoFormat("Directory created at '{0}'", options.MessageFilePath);
            }

            var bodyPattern = (messageName ?? "*") + ".*.message.txt";

            foreach (var file in Directory.GetFiles(options.MessageFilePath, bodyPattern))
            {
                const string messageTag = ".message.";
                var directoryName = Path.GetDirectoryName(file);
                var fileName = Path.GetFileName(file);
                var propertiesFileName = Path.Combine(directoryName, fileName.Replace(messageTag, ".properties."));
                var infoFileName = Path.Combine(directoryName, fileName.Replace(messageTag, ".info."));

                var body = File.ReadAllText(file);

                var propertiesJson = File.ReadAllText(propertiesFileName);
                var properties = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageProperties>(propertiesJson);

                var infoJson = File.ReadAllText(infoFileName);
                var info = Newtonsoft.Json.JsonConvert.DeserializeObject<MessageReceivedInfo>(infoJson);

                yield return new RecoveryMessage(body, properties, info);
            }
        }
    }
}
