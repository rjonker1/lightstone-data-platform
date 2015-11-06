using System.Collections.Generic;
using System.IO;
using Common.Logging;
using Recoveries.Core;
using Recoveries.Domain.Base;
using Recoveries.Shared;

namespace Recoveries
{
    public class DeleteErrorFiles : IDeleteFiles
    {
        private static readonly ILog Log = LogManager.GetLogger<DeleteErrorFiles>();

        public IEnumerable<int> DeleteMessages(IQueueOptions options)
        {
            if (!Directory.Exists(options.MessageFilePath))
            {
                Log.ErrorFormat("Directory '{0}' does not exist", options.MessageFilePath);
                Log.InfoFormat("Creating Directory at '{0}'", options.MessageFilePath);
                options.MessageFilePath.CreateDirectory();
                Log.InfoFormat("Directory created at '{0}'", options.MessageFilePath);
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