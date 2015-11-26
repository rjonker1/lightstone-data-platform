using Microsoft.Practices.ServiceLocation;
using Nancy;
using StackExchange.Redis;

namespace PackageBuilder.Api.Helpers
{
    public class RedisProfiler : IProfiler
    {
        const string RequestContextKey = "RequestProfilingContext";
        private readonly NancyContext _context;
        public RedisProfiler(INancyContextWrapper context)
        {
            _context = context.Context;
        }

        public object GetContext()
        {
            return _context == null ? null : _context.Items[RequestContextKey];
        }

        public object CreateContextForCurrentRequest()
        {
            if (_context == null) return null;

            object ret;
            _context.Items[RequestContextKey] = ret = new object();

            return ret;
        }

        //public object GetContext()
        //{
        //    var context = ServiceLocator.Current.GetInstance<INancyContextWrapper>().Context;
        //    return context == null ? null : context.Items[RequestContextKey];
        //}

        //public object GetContext(NancyContext context)
        //{
        //    return context == null ? null : context.Items[RequestContextKey];
        //}

        //public object CreateContextForCurrentRequest(NancyContext context)
        //{
        //    if (context == null) return null;

        //    object ret;
        //    context.Items[RequestContextKey] = ret = new object();

        //    return ret;
        //}
    }
}