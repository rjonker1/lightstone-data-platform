using Lace.EventHandlers;

namespace Lace.Operations
{
    public class LaceOperation
    {
        private readonly IHandle _laceHandler;
        private readonly IBuild _laceBuilder;

        public LaceOperation(IHandle handler, IBuild builder)
        {
            _laceHandler = handler;
            _laceBuilder = builder;
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
           _laceBuilder.BuildLicensePlateNumberRequest(e.Handlers);
        }

        private void OnLoading(object sender, LoadEventArgs e)
        {
            _laceHandler.HandleRequest(e.Request, e.Handlers);
            e.LaceResponses = _laceHandler.LaceResponses;
        }
    }
}
