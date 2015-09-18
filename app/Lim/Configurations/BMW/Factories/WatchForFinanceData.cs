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

namespace Toolbox.Bmw.Factories
{
    public class WatchForFinanceDataFactory : AbstractWatcherFactory<FileInformationDto>
    {
        private static readonly ILog Log = LogManager.GetLogger<WatchForFinanceDataFactory>();
        private readonly IRead<ReadFile, IEnumerable<BmwFinanceDataDto>> _bmwReader;
        private readonly IBackup<BackupFile> _backup;
        private readonly IFail<FailFile> _fail; 
        private readonly IPersist<List<BmwFinanceDataDto>> _persist;
        private readonly FileSystemWatcher _watcher;
        private FileInformationDto _command;

        public WatchForFinanceDataFactory(IPersist<List<BmwFinanceDataDto>> persist, IRead<ReadFile, IEnumerable<BmwFinanceDataDto>> bmwReader, IBackup<BackupFile> backup, IFail<FailFile> fail)
        {
            _watcher = new FileSystemWatcher();
            _persist = persist;
            _bmwReader = bmwReader;
            _backup = backup;
            _fail = fail;
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

        public void Changed(object source, FileSystemEventArgs args)
        {
            try
            {
                var dto = new FileInformationDto(_command.FilePath, args.Name, _command.Password, "", true,true);
                var data = _bmwReader.Read(
                    new ReadFile(dto)).ToList();

                if (!data.Any())
                {
                    FailFile(dto, args.Name);
                    Log.ErrorFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    return;
                }

                if (!_persist.Persist(data))
                {
                    Log.ErrorFormat("File has been created in Path {0} and has been read but cannot be saved to the database.", args.FullPath);
                    FailFile(dto, args.Name);
                    return;
                }

                BackupFile(dto, args.Name);
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
                var dto = new FileInformationDto(_command.FilePath, args.Name, _command.Password, "", true, true);
                var data = _bmwReader.Read(
                    new ReadFile(dto)).ToList();

                if (!data.Any())
                {
                    FailFile(dto, args.Name);
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    return;
                }


                if (!_persist.Persist(data))
                {
                    Log.ErrorFormat("File has been created in Path {0} and has been read but cannot be saved to the database.", args.FullPath);
                    FailFile(dto, args.Name);
                    return;
                }

                BackupFile(dto, args.Name);
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
                var dto = new FileInformationDto(_command.FilePath, args.Name, _command.Password, "", true, true);
                var data = _bmwReader.Read(
                    new ReadFile(dto)).ToList();

                if (!data.Any())
                {
                    Log.InfoFormat("File has been created in Path {0} but cannot be read", args.FullPath);
                    FailFile(dto, args.Name);
                    return;
                }

                if (!_persist.Persist(data))
                {
                    Log.ErrorFormat("File has been created in Path {0} and has been read but cannot be saved to the database.", args.FullPath);
                    FailFile(dto, args.Name);
                    return;
                }
                    

                BackupFile(dto, args.Name);
            }
            catch (Exception ex)
            {
                Log.ErrorFormat("An error occurred reading file in path {0} because of {1}", ex, args.FullPath, ex.Message);
            }
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