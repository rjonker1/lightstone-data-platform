using System.Collections.Generic;
using Infrastructure.Sql.Messaging;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging
{
    /// <summary>
    /// Abstracts the behavior of sending a message.
    /// </summary>
    public interface IMessageSender
    {
        /// <summary>
        /// Sends the specified message.
        /// </summary>
        void Send(Message message);

        /// <summary>
        /// Sends a batch of messages.
        /// </summary>
        void Send(IEnumerable<Message> messages);
    }
}
