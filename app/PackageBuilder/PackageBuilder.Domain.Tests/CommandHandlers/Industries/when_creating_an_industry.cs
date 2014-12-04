using System;
using System.Linq;
using Moq;
using PackageBuilder.Core.Repositories;
using PackageBuilder.Domain.CommandHandlers.Industries;
using PackageBuilder.Domain.Entities.Industries.Commands;
using PackageBuilder.Domain.Entities.Industries.WriteModels;
using Xunit.Extensions;

namespace PackageBuilder.Domain.Tests.CommandHandlers.Industries
{
    public class when_creating_an_industry : Specification
    {
        private CreateIndustryHandler _handler;
        private readonly Mock<IRepository<Industry>> _repo = new Mock<IRepository<Industry>>();
        public override void Observe()
        {
            var command = new CreateIndustry(Guid.NewGuid(), "Test Industry", false);
            _handler = new CreateIndustryHandler(_repo.Object);
            //_repo.Setup(x => x.FirstOrDefault()).Returns((Industry) null);
            _handler.Handle(command);
        }

        [Observation]
        public void should_save_the_correct_industry()
        {
            //_repo.Verify(s => s.Save(It.Is<Industry>(i => IsTheCorrectIndustry(i))));
        }

        private static bool IsTheCorrectIndustry(Industry industry)
        {
            return industry.Name == "Test Industry";
        }
    }
}