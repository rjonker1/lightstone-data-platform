using System;
using System.Collections.Generic;
using Lace.Builder;
using Lace.EventHandlers;
using Lace.Handler;
using Lace.Operations;
using Lace.Request;
using Lace.Response;
using Lace.Response.ExternalServices;

namespace Lace
{
    public class Initialize : IBootstrap
    {

        public IList<LaceExternalServiceResponse> LaceResponses { get; set; }

        private readonly ILaceRequest _request;
        private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;
        private LaceOperation Bootstrap;

        public Initialize(ILaceRequest request)
        {
            _request = request;

            InitializeHandlers();

            Set();

            LoadSources();
        }

        private void Set()
        {
            var builder = new LaceBuilder();
            var handler = new LaceHandler();

            Bootstrap = new LaceOperation(handler, builder)
            {
                LaceBootstrap = this
            };
        }

        private void InitializeHandlers()
        {
            var args = new SetHandlersEventArgs();
            SetHandlers(this, args);
            _handlers = args.Handlers ?? new Dictionary<Type, Func<ILaceRequest, ILaceResponse>>();
        }

        private void LoadSources()
        {
            var args = new LoadEventArgs(_request, _handlers);
            Load(this, args);
            LaceResponses = args.LaceResponses;
        }


        public event EventHandler<LoadEventArgs> Load;
        public event EventHandler<SetHandlersEventArgs> SetHandlers;
       

        //public IList<LaceExternalServiceResponse> LaceResponses { get; set; }

        //private LaceOperation operation;
        //private ILaceRequest _request;

        //public Initialize(ILaceRequest request)
        //{
        //    _request = request;
        //    operation = new LaceOperation();
        //    operation.Operation = this;
        //}



        //private Dictionary<Type, Func<ILaceRequest, ILaceResponse>> _handlers;
        //private ILaceRequest _request;

        //public List<LaceExternalServiceResponse> LaceResponses { get; set; }

        //public Initialize()
        //{
        //    LaceResponses = new List<LaceExternalServiceResponse>();
        //}

        //public Initialize Bootstrap(ILaceRequest request)
        //{
        //    _handlers = new Dictionary<Type, Func<ILaceRequest, ILaceResponse>>
        //    {
        //        {typeof(LicensePlateNumberRequest), r => LicensePlateNumberSourceChain.Build(r).Response }
        //    };

        //    _request = request;
        //    return this;
        //}


        //public Initialize Load()
        //{
        //    foreach (var handler in _handlers)
        //    {
        //        LaceResponses.Add(new LaceExternalServiceResponse() {Response = handler.Value(_request), Request = _request});
        //    }

        //    return this;
        //}







       
    }
}
