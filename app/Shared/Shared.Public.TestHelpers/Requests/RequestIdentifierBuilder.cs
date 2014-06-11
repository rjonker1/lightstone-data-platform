using System;
using DataPlatform.Shared.Public.Identifiers;
using Shared.Public.TestHelpers.Systems;

namespace Shared.Public.TestHelpers.Requests
{
    public class RequestIdentifierBuilder
    {
        private Guid id;
        private SystemIdentifierBuilder system;

        public RequestIdentifier Build()
        {
            return new RequestIdentifier(id, system.Build());
        }

        public RequestIdentifierBuilder With(IDefineRequestIdentifier data)
        {
            return WithId(data.Id)
                .WithSystem(data.SystemIdentifier);
        }

        public RequestIdentifierBuilder WithId(Guid id)
        {
            this.id = id;
            return this;
        }

        public RequestIdentifierBuilder WithSystem(SystemIdentifierBuilder systemBuilder)
        {
            this.system = systemBuilder;
            return this;
        }
    }
}