using System.Collections.Generic;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging
{
    public interface ICommandBus
    {
        void Send(Envelope<ICommand> command);
        void Send(IEnumerable<Envelope<ICommand>> commands);
    }
}
