using System;
using System.Collections.Generic;
using System.IO;
using Common.Logging;

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
                throw new Exception(string.Format("Directory '{0}' does not exist", options.MessageFilePath));
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