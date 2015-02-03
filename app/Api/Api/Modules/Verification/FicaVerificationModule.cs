using System;
using Api.Extensions;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Dto;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using Nancy;
using Nancy.ModelBinding;

namespace Api.Modules.Verification
{
    public class FicaVerificationModule : VerificationSecureModule
    {
        public FicaVerificationModule(IHandleFicaVerficationRequests handler)
        {
            Get["/ficaVerification"] = _ => _metaData.AsJsonString();

            Post["/ficaVerification/"] = _ =>
            {
                var request = this.Bind<IHaveFicaVerficationRequest>();
                handler.Handle(new VerifyPersonsFicaInformationCommand(request));
                return handler.FicaVerficationResponse.AsJsonString();
            };
        }

        private readonly IHaveFicaVerficationResponse _metaData = new FicaVerficationResponseDto(0, Guid.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            DateTime.MinValue, DateTime.MinValue);
    }
}