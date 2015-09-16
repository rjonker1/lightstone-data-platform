using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Commands;
using Lim.Domain.Dto;
using Lim.Infrastructure;
using Toolbox.Bmw.Dtos;

namespace Toolbox.Bmw.Finance
{
    public class WatchForFinanceDataFactory : AbstractDirectoryWatcherFactory<FileInformationDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<WatchForFinanceDataFactory>();
        private readonly IReadFile<ReadFile, IEnumerable<BmwFinanceDataDto>> _bmwFileReader;
        private readonly IBackupFile<BackupFile> _backup;
        private readonly IPersistObject<List<BmwFinanceDataDto>> _persist;
        private readonly FileSystemWatcher _watcher;
        private FileInformationDto _command;

        public WatchForFinanceDataFactory(IPersistObject<List<BmwFinanceDataDto>> persist, IReadFile<ReadFile, IEnumerable<BmwFinanceDataDto>> bmwFileReader, IBackupFile<BackupFile> backup)
        {
            _watcher = new FileSystemWatcher();
            _persist = persist;
            _bmwFileReader = bmwFileReader;
            _backup = backup;
        }

        public override void Intialize(FileInformationDto command)
        {
            _command = command;
            _watcher.Path = command.FilePath;
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.CreationTime;
             _watcher.Filter = "*.zip"; // command.FileExtensions;
            _watcher.Created += Created;
            _watcher.Changed += Changed;
            _watcher.Deleted += Deleted;
            _watcher.Renamed += Renamed;
        }

        public void Changed(object source, FileSystemEventArgs args)
        {
            try
            {
                var data = _bmwFileReader.ReadFile(
                    new ReadFile(new FileInformationDto(_command.FilePath, args.Name,_command.Password, "", true))).ToList();

                if (!data.Any())
                {
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    return;
                }

                if (!_persist.Persist(data))
                    return;

                _backup.Backup(new BackupFile(_command,
                    new FileInformationDto(ConfigurationReader.Bmw.BackupFilePath, args.Name, "", "", true)));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred reading file in path {0} because of {1}", ex, args.FullPath, ex.Message);
            }
        }

        public void Created(object source, FileSystemEventArgs args)
        {
            try
            {
                var data = _bmwFileReader.ReadFile(
                    new ReadFile(new FileInformationDto(_command.FilePath, args.Name, _command.Password, "", true))).ToList();

                if (!data.Any())
                {
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    return;
                }

                if (!_persist.Persist(data))
                    return;

                _backup.Backup(new BackupFile(_command,
                    new FileInformationDto(ConfigurationReader.Bmw.BackupFilePath, args.Name, "","", true)));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred reading file in path {0} because of {1}", ex, args.FullPath, ex.Message);
            }
        }

        public void Deleted(object source, FileSystemEventArgs args)
        {
            Log.InfoFormat("File has been deleted in Path {0}", args.FullPath);
        }

        public void Renamed(object source, FileSystemEventArgs args)
        {
            try
            {
                var data = _bmwFileReader.ReadFile(
                    new ReadFile(new FileInformationDto(_command.FilePath, args.Name, _command.Password, "",true))).ToList();

                if (!data.Any())
                {
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    return;
                }

                if (!_persist.Persist(data))
                    return;

                _backup.Backup(new BackupFile(_command,
                    new FileInformationDto(ConfigurationReader.Bmw.BackupFilePath, args.Name, "", "", true)));
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred reading file in path {0} because of {1}", ex, args.FullPath, ex.Message);
            }
        }
    }
}