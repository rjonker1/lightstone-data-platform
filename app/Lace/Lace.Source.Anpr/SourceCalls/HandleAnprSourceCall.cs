using System;
namespace Lace.Source.Anpr.SourceCalls
{
    public class HandleAnprSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromAnprSource());
        }
    }
}
