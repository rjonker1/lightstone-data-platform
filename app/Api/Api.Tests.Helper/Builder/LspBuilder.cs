﻿using Lace.Domain.Core.Entities;
using Lace.Domain.Infrastructure.Core.Dto;

namespace Api.Tests.Helper.Builder
{
    public class LspBuilder
    {
        public LaceExternalSourceResponse ForLspResponseFromLace()
        {
           // throw new System.NotImplementedException();

            return new LaceExternalSourceResponse()
            {
                Response = new LaceResponse()
                {
                    // TODO: update after Lightstone Package updated

                    // Seems that the package Domain.Core.Entities package did not publish so try again.
                    //LspResponse =
                    //     new LspResponse(new Lace.Domain.Core.Entities.ReturnPropertiesResponse(),
                    //         string.Empty),
                    //LspResponseHandled = new LspResponseHandled()
                }
            };
        }
    }
}