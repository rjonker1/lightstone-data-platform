using System;

namespace Lace.Source.Jis.SourceCalls
{
    public class HandleJisSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromJisSource());
        }
    }
}
