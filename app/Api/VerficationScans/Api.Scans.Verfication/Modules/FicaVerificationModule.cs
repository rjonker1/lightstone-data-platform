using System;
using Api.Scans.Verfication.Core.Contracts;
using Api.Scans.Verfication.Core.Extensions;
using Api.Scans.Verfication.Infrastructure.Commands;
using Api.Scans.Verfication.Infrastructure.Dto;
using Nancy.ModelBinding;

namespace Api.Scans.Verfication.Modules
{
    public class FicaVerificationModule : SecureModule
    {
        public FicaVerificationModule(IHandleFicaVerficationRequests handler)
        {
            Get["/ficaVerification"] = _ => _metaData;

            Post["/ficaVerification/"] = _ =>
            {
                var request = this.Bind<FicaVerficationRequestDto>();
                handler.Handle(new VerifyPersonsFicaInformationCommand(request));
                return handler.FicaVerficationResponse.AsJsonString();
            };
        }

        private readonly Func<FicaVerficationResponseDto> _metaData =
            () =>
                new FicaVerficationResponseDto(0, Guid.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    DateTime.MinValue, DateTime.MinValue);
    }
}