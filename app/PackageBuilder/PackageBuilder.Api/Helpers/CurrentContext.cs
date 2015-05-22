using Nancy;

namespace PackageBuilder.Api.Helpers
{
    public class CurrentContext
    {
        private NancyContext _context;
        public NancyContext Context
        {
            get
            {
                return _context;
            }
            set
            {
                _context = value;
            }
        }
    }
}