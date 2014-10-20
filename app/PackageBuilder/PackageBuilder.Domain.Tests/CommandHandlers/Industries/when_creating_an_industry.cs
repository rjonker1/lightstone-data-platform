using System;
using Moq;
using PackageBuilder.Domain.CommandHandlers.Industries;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using Raven.Client;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Industries
{
    public class when_creating_an_industry : Specification
    {
        private CreateIndustryHandler _handler;
        private readonly Mock<IDocumentSession> _session = new Mock<IDocumentSession>();
        public override void Observe()
        {
            var command = new CreateIndustry(Guid.NewGuid(), "Test Industry");
            //_handler = new CreateIndustryHandler(_session.Object);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save_the_correct_industry()
        {
            _session.Verify(s => s.Store(It.Is<Industry>(i => IsTheCorrectIndustry(i))));
        }

        private static bool IsTheCorrectIndustry(Industry industry)
        {
            return industry.Name == "Test Industry";
        }
    }
}