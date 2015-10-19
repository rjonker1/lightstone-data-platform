using System;
using System.Collections.Generic;
using DataPlatform.Shared.Enums;
using Lace.Domain.Core.Contracts.DataProviders.Property;
using Lace.Domain.Core.Entities;

namespace PackageBuilder.Domain.CommandHandlers.DataProviders.Responses
{
    public class LightstonePropertyResponse
    {
        public Lace.Domain.Core.Entities.LightstonePropertyResponse Default()
        {
            var result = new Lace.Domain.Core.Entities.LightstonePropertyResponse(new List<IRespondWithProperty>()
            {
                new PropertyModel(0, 0M, 0M, 0M, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, 0, 0M, string.Empty, string.Empty, string.Empty, string.Empty, string.Empty,
                    string.Empty, string.Empty, string.Empty, 0M, 0M, string.Empty, string.Empty, string.Empty,
                    Guid.Empty, 0, string.Empty, 0, 0, 0D, 0D, 0D, string.Empty, string.Empty, string.Empty,
                    string.Empty, 0, 0, string.Empty, string.Empty, string.Empty, 0, 0M, string.Empty, string.Empty, 0,
                    0, false)
            });
            result.AddResponseState(DataProviderResponseState.NoRecords);
            return result;
        } 
    }
}