namespace Lim.Core
{
    public interface ISendCommand
    {
        void Send<T>(T command) where T : Command;
    }
}
