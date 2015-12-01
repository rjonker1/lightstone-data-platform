namespace Toolbox.LightstoneAuto.Database.Domain.Base
{
    public interface ICommandSender
    {
        void Send<T>(T command) where T : Command;
    }
}
