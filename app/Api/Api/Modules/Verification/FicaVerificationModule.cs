using System;
using Api.Domain.Verification.Core.Contracts;
using Api.Domain.Verification.Infrastructure.Commands;
using Api.Domain.Verification.Infrastructure.Dto;
using Api.Domain.Verification.Infrastructure.Handlers.Contracts;
using Nancy;
using Nancy.ModelBinding;

namespace Api.Modules.Verification
{
    public class FicaVerificationModule : VerificationModule
    {
        public FicaVerificationModule(IHandleFicaVerficationRequests handler)
        {
            Get["/ficaVerification"] = _ => Response.AsJson(new
            {
                _request,
                _response
            });

            Post["/ficaVerification/"] = _ =>
            {
                var request = this.Bind<FicaVerficationRequestDto>();
                handler.Handle(new VerifyPersonsFicaInformationCommand(request));
                return Response.AsJson(handler.FicaVerficationResponse);
            };
        }

        private readonly IHaveFicaVerficationResponse _response = new FicaVerficationResponseDto(0, Guid.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            DateTime.MinValue, DateTime.MinValue);

        private readonly IHaveFicaVerficationRequest _request = new FicaVerficationRequestDto(000000000, string.Empty, 0,
            Guid.Empty);
    }
}