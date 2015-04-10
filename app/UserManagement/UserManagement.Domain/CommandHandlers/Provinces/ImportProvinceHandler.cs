using UserManagement.Domain.Core.MessageHandling;
using UserManagement.Domain.Dtos;
using UserManagement.Domain.Entities;
using UserManagement.Domain.Entities.Commands.Provinces;

namespace UserManagement.Domain.CommandHandlers.Provinces
{
    public class ImportProvinceHandler : AbstractMessageHandler<ImportProvince>
    {
        private readonly IHandleMessages _handler;

        public ImportProvinceHandler(IHandleMessages handler)
        {
            _handler = handler;
        }

        public override void Handle(ImportProvince command)
        {
            _handler.Handle(new ValueEntityDto("Eastern Cape", typeof(Province)));
            _handler.Handle(new ValueEntityDto("Free State", typeof(Province)));
            _handler.Handle(new ValueEntityDto("Gauteng", typeof(Province)));
            _handler.Handle(new ValueEntityDto("KwaZulu-Natal", typeof(Province)));
            _handler.Handle(new ValueEntityDto("Limpopo", typeof(Province)));
            _handler.Handle(new ValueEntityDto("Mpumalanga", typeof(Province)));
            _handler.Handle(new ValueEntityDto("North West", typeof(Province)));
            _handler.Handle(new ValueEntityDto("Northern Cape", typeof(Province)));
            _handler.Handle(new ValueEntityDto("Western Cape", typeof(Province)));
        }
    }
}