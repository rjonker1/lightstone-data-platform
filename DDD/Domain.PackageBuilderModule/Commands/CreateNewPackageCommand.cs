using System;
using System.Windows.Input;
using LightstoneApp.Domain.PackageBuilderModule.Entities;

namespace LightstoneApp.Domain.PackageBuilderModule.Commands
{
    public class CreateNewPackageCommand : ICommand
    {

        public bool CanExecute(object parameter)
        {
            var package = parameter as Package;

            if (package != null)
            {
                // TODO: validate the command

                if (string.IsNullOrEmpty(package.Name))
                    return false;


                if (package.DataSources == null)
                    return false;

                Name = package.Name;
                Version = package.Version;

                return true;
            }

            return false;
        }

        public void Execute(object parameter)
        {
            var package = parameter as Package;
            if (package != null)
            {
                // 
            }

        }

        public event EventHandler CanExecuteChanged;

       
        public string Name { get; private set; }
        public int Version { get; private set; }
    }
}
