using System.Collections.Generic;
using Nancy;
using Nancy.Bootstrapper;

namespace PackageBuilder.Api.Helpers
{
    public class NancyContextWrapperRegistration : IRegistrations
    {
        public IEnumerable<TypeRegistration> TypeRegistrations
        {
            get
            {
                return new[]
                {
                    new TypeRegistration(typeof (INancyContextWrapper), typeof (NancyContextWrapper),
                        Lifetime.PerRequest),
                };
            }
        }

        public IEnumerable<CollectionTypeRegistration> CollectionTypeRegistrations { get; private set; }
        public IEnumerable<InstanceRegistration> InstanceRegistrations { get; private set; }
    }

    public interface INancyContextWrapper
    {
        NancyContext Context { get; set; }
    }

    public class NancyContextWrapper : INancyContextWrapper
    {
        private NancyContext _context;
        public NancyContext Context
        {
            get { return _context; }
            set { _context = value; } //do something here if you want to prevent repeated sets
        }
    }

    public class PrepareNancyContextWrapper : IRequestStartup
    {
        private readonly INancyContextWrapper _nancyContext;
        public PrepareNancyContextWrapper(INancyContextWrapper nancyContext)
        {
            _nancyContext = nancyContext;
        }

        public void Initialize(IPipelines piepeLinse, NancyContext context)
        {
            _nancyContext.Context = context;
        }
    }
}