using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Base;
using Lim.Domain.Commands;
using Lim.Dtos;
using Lim.Enums;
using Lim.Infrastructure;
using Toolbox.Bmw.Dtos;

namespace Toolbox.Bmw.Factories
{
    public class WatchForFinanceDataFileFactory : AbstractWatcherFactory<FileInformationDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<WatchForFinanceDataFileFactory>();
        private readonly IRead<ReadFile, IEnumerable<BmwFinanceDataDto>> _fileReader;
        private readonly IBackup<BackupFile> _backup;
        private readonly IFail<FailFile> _fail;
        private readonly IPersist<List<BmwFinanceDataDto>> _persist;
        private readonly INotify<NotifyFile> _notify;
        private readonly FileSystemWatcher _watcher;
        private FileInformationDto _command;

        public WatchForFinanceDataFileFactory(IPersist<List<BmwFinanceDataDto>> persist, IRead<ReadFile, IEnumerable<BmwFinanceDataDto>> fileReader,
            IBackup<BackupFile> backup, IFail<FailFile> fail, INotify<NotifyFile> notify)
        {
            _watcher = new FileSystemWatcher();
            _persist = persist;
            _fileReader = fileReader;
            _backup = backup;
            _fail = fail;
            _notify = notify;
        }

        public override void Intialize(FileInformationDto command)
        {
            _command = command;
            _watcher.Path = command.FilePath;
            _watcher.IncludeSubdirectories = true;
            _watcher.EnableRaisingEvents = true;
            _watcher.NotifyFilter = NotifyFilters.FileName | NotifyFilters.LastWrite | NotifyFilters.Size | NotifyFilters.CreationTime;
            _watcher.Filter = command.FileExtension;
            _watcher.Created += Created;
            _watcher.Changed += Changed;
            _watcher.Deleted += Deleted;
            _watcher.Renamed += Renamed;
        }
        public void Created(object source, FileSystemEventArgs args)
        {
            try
            {
                _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                    string.Format("Received file {0} in Path {1}. File will be processed.", args.Name, args.FullPath), Status.Received));

                var dto = new FileInformationDto(_command.FilePath, args.Name, _command.Password, "", true, true);
                var data = _fileReader.Read(new ReadFile(dto)).ToList();

                if (!data.Any())
                {
                    FailFile(dto, args.Name);
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                        string.Format("File {0} in Path {1} could not be read.", args.Name, args.FullPath), Status.Failed));
                    return;
                }


                if (!_persist.Persist(data))
                {
                    _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                        string.Format("File {0} in Path {1} could not be processed.", args.Name, args.FullPath), Status.Failed));
                    Log.ErrorFormat("File has been created in Path {0} and has been read but cannot be saved to the database.", args.FullPath);
                    FailFile(dto, args.Name);
                    return;
                }

                BackupFile(dto, args.Name);
                _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                    string.Format("File {0} in Path {1} has been processed.", args.Name, args.FullPath), Status.Successful));
            }
            catch (Exception ex)
            {
                _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                    string.Format("An error occurred processing File {0} in Path {1}.", args.Name, args.FullPath), Status.Failed));
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
                _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                    string.Format("Received file {0} in Path {1}. File will be processed.", args.Name, args.FullPath), Status.Received));

                var dto = new FileInformationDto(_command.FilePath, args.Name, _command.Password, "", true, true);
                var data = _fileReader.Read(new ReadFile(dto)).ToList();

                if (!data.Any())
                {
                    FailFile(dto, args.Name);
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                        string.Format("File {0} in Path {1} could not be read.", args.Name, args.FullPath), Status.Failed));
                    return;
                }


                if (!_persist.Persist(data))
                {
                    _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                        string.Format("File {0} in Path {1} could not be processed.", args.Name, args.FullPath), Status.Failed));
                    Log.ErrorFormat("File has been created in Path {0} and has been read but cannot be saved to the database.", args.FullPath);
                    FailFile(dto, args.Name);
                    return;
                }

                BackupFile(dto, args.Name);
                _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                    string.Format("File {0} in Path {1} has been processed.", args.Name, args.FullPath), Status.Successful));
            }
            catch (Exception ex)
            {
                _notify.Notify(new NotifyFile(args.Name, args.FullPath,
                    string.Format("An error occurred processing File {0} in Path {1}.", args.Name, args.FullPath), Status.Failed));
                Log.ErrorFormat("An error occurred reading file in path {0} because of {1}", ex, args.FullPath, ex.Message);
            }
        }
        public void Changed(object source, FileSystemEventArgs args)
        {
            Log.InfoFormat("File has been changed in Path {0}", args.FullPath);
        }
        private void BackupFile(FileInformationDto dto, string fileName)
        {
            _backup.Backup(new BackupFile(dto,
                new FileInformationDto(ConfigurationReader.Bmw.BackupFilePath, fileName, "", "", true, true)));
        }

        private void FailFile(FileInformationDto dto, string fileName)
        {
            _fail.Fail(new FailFile(dto,
                new FileInformationDto(ConfigurationReader.Bmw.FailFilePath, fileName, "", "", true, true)));
        }
    }
}