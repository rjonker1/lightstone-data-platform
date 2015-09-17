using System;
using System.IO;
using System.Linq;
using Common.Logging;
using Lim.Domain.Base;
using Lim.Domain.Commands;
using Lim.Domain.Extensions;

namespace Toolbox.Bmw.Finance
{
    public class BackupFinanceDataFactory : AbstractFileBackupFactory<BackupFile>
    {
        private readonly ILog _log = LogManager.GetLogger<ReadFinanceDataFactory>();

        public override bool Backup(BackupFile command)
        {
            var path = command.FileBackup.FilePath + string.Format(@"\{0}", DateTime.Now.YearMonthDay());
            if (!Directory.Exists(path))
                Directory.CreateDirectory(path);

            var fileCount = Directory.GetFiles(path).Any() ? Directory.GetFiles(path).Count() : 0;
            var backupFileName = Path.GetFileNameWithoutExtension(command.FileBackup.FileName) + "_" + fileCount +
                                 Path.GetExtension(command.FileBackup.FileName);

            File.Copy(Path.Combine(command.File.FilePath, command.File.FileName), Path.Combine(path, backupFileName));

            if (!Directory.GetFiles(path).Any() && Directory.GetFiles(path).Count() == fileCount)
                return false;

            File.Delete(Path.Combine(command.File.FilePath, command.File.FileName));

            return true;
        }
    }
}