using Workflow.DataProvider.Bus.Domain.Indentifiers;

namespace Workflow.DataProvider.Bus.Domain
{
    public class DataProviderCommand
    {
        public DataProviderCommand(CommandIndentifier command)
        {
            Command = command;
        }
        public CommandIndentifier Command { get; private set; }
    }
}
