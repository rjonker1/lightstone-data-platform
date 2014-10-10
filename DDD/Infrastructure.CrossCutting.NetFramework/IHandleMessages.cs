namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    public interface IHandleMessages<T> where T : IDomainEvent
    {
        // Summary:
        //     Handles a message.
        //
        // Parameters:
        //   message:
        //     The message to handle.
        //
        // Remarks:
        //     This method will be called when a message arrives on the bus and should contain
        //     the custom logic to execute when the message is received.
        void Handle(T message);
    }
}