using System.Collections.Generic;
using System.IO;
using System.Text.RegularExpressions;
using Common.Logging;
using Recoveries.Core;
using Recoveries.Domain.Base;

namespace Recoveries
{
    public class FileMessageWriter : IMessageWriter
    {
        private static readonly ILog Log = LogManager.GetLogger<FileMessageWriter>();

        private static readonly Regex InvalidCharRegex = new Regex(@"[\\\/:\*\?\""\<\>|]");

        public void Write(IEnumerable<RecoveryMessage> messages, IQueueOptions options)
        {
            var count = 0;
            foreach (var message in messages)
            {
                var uniqueFileName = SanitiseQueueName(options.ErrorQueueName) + "." + count.ToString();

                var bodyPath = Path.Combine(options.MessageFilePath, uniqueFileName + ".message.txt");
                var propertiesPath = Path.Combine(options.MessageFilePath, uniqueFileName + ".properties.txt");
                var infoPath = Path.Combine(options.MessageFilePath, uniqueFileName + ".info.txt");

                if (File.Exists(bodyPath))
                    Log.InfoFormat("Overwriting existing messsage file: {0}", bodyPath);

                try
                {
                    File.WriteAllText(bodyPath, message.Body);
                    File.WriteAllText(propertiesPath, Newtonsoft.Json.JsonConvert.SerializeObject(message.Properties));
                    File.WriteAllText(infoPath, Newtonsoft.Json.JsonConvert.SerializeObject(message.Info));
                }
                catch (DirectoryNotFoundException)
                {
                    throw new EasyNetQException(string.Format("Directory '{0}' does not exist", options.MessageFilePath));
                }
                count++;
            }
        }

        public static string SanitiseQueueName(string queueName)
        {
            return InvalidCharRegex.Replace(queueName, "_");
        }
    }
}