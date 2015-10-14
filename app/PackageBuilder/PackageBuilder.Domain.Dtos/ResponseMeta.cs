using System;

namespace PackageBuilder.Domain.Dtos
{
    public class ResponseMeta : IProvideResponseDataProvider
    {
        public Guid RequestId { get; set; }
    }
}