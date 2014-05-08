using Lace.EventHandlers;
namespace Lace.Operations
{
    public class LaceOperation
    {
       
        private readonly ILoadRequestSources _laceLoader;
        public LaceOperation(ILoadRequestSources laceLoader)
        {
            _laceLoader = laceLoader;
        }

        private IBootstrap _laceBootstrap;
        public IBootstrap LaceBootstrap
        {
            get
            {
                return _laceBootstrap;
            }
            set
            {
                _laceBootstrap = value;
                AttachEvents();
            }

        }

        private void AttachEvents()
        {
            _laceBootstrap.Load += OnLoading;
            _laceBootstrap.SetHandlers += OnSettingHandlers;
        }

        private void OnSettingHandlers(object sender, SetHandlersEventArgs e)
        {
            _laceLoader.BuildRequest(e.Handlers);
        }

        private void OnLoading(object sender, LoadEventArgs e)
        {
            _laceLoader.HandleRequest(e.Request, e.Handlers);
            e.LaceResponses = _laceLoader.LaceResponses;
        }
    }
}
