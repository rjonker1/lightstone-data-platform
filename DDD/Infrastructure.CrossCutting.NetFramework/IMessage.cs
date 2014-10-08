using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework
{
    // Summary:
    //     Marker interface to indicate that a class is a message suitable for transmission
    //     and handling by an NServiceBus.
    public interface IMessage
    {
    }

    public interface IBus
    {
        void Publish(IDomainEvent @event);
    }

    // Summary:
    //     Defines a message handler.
    //
    // Type parameters:
    //   T:
    //     The type of message to be handled.
    public interface IHandleMessages<T>
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
