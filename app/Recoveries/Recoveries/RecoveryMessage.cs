using System;
using EasyNetQ;

namespace Recoveries
{
    public class RecoveryMessage
    {
        public string Body { get; private set; }
        public MessageProperties Properties { get; private set; }
        public MessageReceivedInfo Info { get; private set; }

        public RecoveryMessage(string body, MessageProperties properties, MessageReceivedInfo info)
        {
            if (body == null) throw new ArgumentNullException("body");
            if (properties == null) throw new ArgumentNullException("properties");
            if (info == null) throw new ArgumentNullException("info");

            Body = body;
            Properties = properties;
            Info = info;
        }
    }
}
