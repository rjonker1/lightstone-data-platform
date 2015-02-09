using System;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Dto;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using Lace.Shared.Extensions;
using Nancy.ModelBinding;

namespace Api.Modules.Verification
{
    public class FicaVerificationModule : VerificationSecureModule
    {
        public FicaVerificationModule(IHandleFicaVerficationRequests handler)
        {
            Get["/ficaVerification"] = _ => new
            {
                _request,
                _response
            }.AsJsonString();

            Post["/ficaVerification/"] = _ =>
            {
                var request = this.Bind<FicaVerficationRequestDto>();
                handler.Handle(new VerifyPersonsFicaInformationCommand(request));
                return handler.FicaVerficationResponse.AsJsonString();
            };
        }

        private readonly IHaveFicaVerficationResponse _response = new FicaVerficationResponseDto(0, Guid.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            DateTime.MinValue, DateTime.MinValue);

        private readonly IHaveFicaVerficationRequest _request = new FicaVerficationRequestDto(000000000, string.Empty, 0,
            Guid.Empty);
    }
}