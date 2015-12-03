namespace Lim.Core
{
    public interface ISendCommands
    {
        void Send<T>(T command) where T : Command;
    }
}
