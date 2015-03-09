using System;
using DataPlatform.Shared.Entities;

namespace Lace.Domain.Core.Contracts.DataProviders.Lsp
{
    public interface IRespondWithReturnPropertiesRequestData : IProvideType
    {
        /// <summary>
        /// This is uniquely identifies the request to the service
        /// </summary>
        Guid Req_ID { get; set; }

        /// <summary>
        /// This field reports the success or failure of the method call. If the method call is successful the field is blank
        /// </summary>
        string ErrorMessage { get; set; }

    }
}