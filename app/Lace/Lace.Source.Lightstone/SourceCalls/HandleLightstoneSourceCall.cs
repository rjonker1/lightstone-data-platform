using System;
namespace Lace.Source.Lightstone.SourceCalls
{
    public class HandleLightstoneSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromLightstoneSource());
        }
    }
}
