using System.Linq;
using Common.Logging;
using Lim.Core;
using Lim.Domain.Dto;
using Lim.Schedule.Core.Commands;

namespace Lim.Schedule.Core.Handlers
{
    public class HandleExecutingFlatFileConfiguration : IHandleExecutingFlatFileConfiguration
    {
        private static readonly ILog Log = LogManager.GetLogger<HandleExecutingFlatFileConfiguration>();
        private readonly IWatchDirectory<FileInformationDto> _watchDirectory;


        public HandleExecutingFlatFileConfiguration(IWatchDirectory<FileInformationDto> watchDirectory)
        {
            _watchDirectory = watchDirectory;
        }

        public void Handle(ExecuteFlatFilePullConfigurationCommand command)
        {
            Log.Info("Handling Flat File Pull Configurations");

            command.Configurations.ToList().ForEach(f =>
            {
                _watchDirectory.Intialize(new FileInformationDto(f.File.FilePath,f.File.FileName,f.File.Password,f.File.Extension, f.File.FirstRowIsColumnName));
            });

            IsHandled = true;
        }

        public void Handle(ExecuteFlatFilePushConfigurationCommand command)
        {
            Log.Info("Handling Flat File Push Configurations");
            IsHandled = false;
        }

        public bool IsHandled { get; private set; }
    }
}
