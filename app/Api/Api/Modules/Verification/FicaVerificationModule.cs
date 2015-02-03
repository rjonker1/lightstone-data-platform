using System;
using Api.Extensions;
using Api.Verfication.Core.Contracts;
using Api.Verfication.Infrastructure.Commands;
using Api.Verfication.Infrastructure.Dto;
using Api.Verfication.Infrastructure.Handlers.Contracts;
using Nancy.ModelBinding;

namespace Api.Modules.Verification
{
    public class FicaVerificationModule : VerificationSecureModule
    {
        public FicaVerificationModule(IHandleFicaVerficationRequests handler)
        {
            Get["/ficaVerification"] = _ => _requestMetaData.AsJsonString();

            Post["/ficaVerification/"] = _ =>
            {
                var request = this.Bind<FicaVerficationRequestDto>();
                handler.Handle(new VerifyPersonsFicaInformationCommand(request));
                return handler.FicaVerficationResponse.AsJsonString();
            };
        }

        private readonly IHaveFicaVerficationResponse _metaData = new FicaVerficationResponseDto(0, Guid.Empty,
            string.Empty, string.Empty, string.Empty, string.Empty,
            DateTime.MinValue, DateTime.MinValue);

        private readonly IHaveFicaVerficationRequest _requestMetaData = new FicaVerficationRequestDto(000000000, string.Empty, 0, Guid.Empty);
    }
}