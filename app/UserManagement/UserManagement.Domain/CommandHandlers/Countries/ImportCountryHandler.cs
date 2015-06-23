using System.Globalization;
using System.Linq;
using MemBus;
using UserManagement.Domain.Core.Helpers;
using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Countries;
using UserManagement.Domain.Entities.Commands.Entities;

namespace UserManagement.Domain.CommandHandlers.Countries
{
    public class ImportCountryHandler : AbstractMessageHandler<ImportCountry>
    {
        private readonly IBus _bus;

        public ImportCountryHandler(IBus bus)
        {
            _bus = bus;
        }

        public override void Handle(ImportCountry command)
        {
            CultureInfo.GetCultures(CultureTypes.SpecificCultures).Select(x => new RegionInfo(x.LCID).EnglishName)
                .Distinct().ToList()
                .ForEach(x => ExceptionHelper.IgnoreException(() => _bus.Publish(new CreateUpdateEntity(new Country(x), "Create"))));
        }
    }
}