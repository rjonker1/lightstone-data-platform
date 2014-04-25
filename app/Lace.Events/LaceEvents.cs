using Common.Logging;

namespace Lace.Events
{
    public class LaceEvents
    {
       // private static readonly ILog Log = LogManager.GetCurrentClassLogger();

        public static void Raise(ILaceChainEvent laceEvent)
        {
            
        }
        //public static void Raise<T>(T args) where T : ILaceEvent
        //{
        //    //Raise the Event to Event DB Store
        //}
    }
}
