using System;
using System.Collections.Generic;
using System.IO;
using Common.Logging;
using Recoveries.Core;
using Recoveries.Domain;

namespace Recoveries
{
    public interface IDeleteFiles
    {
        IEnumerable<int> DeleteMessages(IQueueOptions options);
    }

    public class DeleteErrorFiles : IDeleteFiles
    {
        private readonly ILog _log = LogManager.GetLogger<DeleteErrorFiles>();

        public IEnumerable<int> DeleteMessages(IQueueOptions options)
        {
            if (!Directory.Exists(options.MessageFilePath))
            {
                _log.ErrorFormat("Directory '{0}' does not exist", options.MessageFilePath);
                _log.InfoFormat("Creating Directory at '{0}'", options.MessageFilePath);
                options.MessageFilePath.CreateDirectory();
                _log.InfoFormat("Directory created at '{0}'", options.MessageFilePath);
            }
            var count = 0;
            foreach (var file in new DirectoryInfo(options.MessageFilePath).GetFiles())
            {
                file.Delete();
                count++;
                yield return count;
            }
        }
    }
}