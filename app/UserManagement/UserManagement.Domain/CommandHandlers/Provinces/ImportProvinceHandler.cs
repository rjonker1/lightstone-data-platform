using System;
using System.Collections;
using UserManagement.Domain.Core.MessageHandling;
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
            IList provinces = new ArrayList();

            provinces.Add("Eastern Cape");
            provinces.Add("Free State");
            provinces.Add("Gauteng");
            provinces.Add("KwaZulu-Natal");
            provinces.Add("Limpopo");
            provinces.Add("Mpumalanga");
            provinces.Add("North West");
            provinces.Add("Northern Cape");
            provinces.Add("Western Cape");

            foreach (object province in provinces)
            {
                _handler.Handle(new CreateProvince(province.ToString()));
            }
        }
    }
}