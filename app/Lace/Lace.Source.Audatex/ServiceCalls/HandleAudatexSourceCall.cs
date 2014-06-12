using System;

namespace Lace.Source.Audatex.ServiceCalls
{
    public class HandleAudatexSourceCall : IHandleSourceCall
    {
        public void Request(Action<IRequestDataFromSource> action)
        {
            action(new RequestDataFromAudatexSource());
        }
    }
}
