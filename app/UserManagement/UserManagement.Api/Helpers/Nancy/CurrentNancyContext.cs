using Nancy;

namespace UserManagement.Api.Helpers.Nancy
{
    public class CurrentNancyContext
    {
        private NancyContext context;
        public NancyContext NancyContext
        {
            get { return context; }
            set { context = value; }
        }
    }
}