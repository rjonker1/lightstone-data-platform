using System;
using System.Linq;
using System.Web.Mvc;
using Lace.Models.Ivid.Dto;
using PackageBuilder.Common.Helpers.Extensions;
using PackageBuilder.Domain.Helpers.MessageHandling;

namespace PackageBuilder.Web.Controllers
{
    public class DataProviderController : Controller
    {
        private readonly IHandleMessages _handler;

        public DataProviderController(IHandleMessages handler)
        {
            _handler = handler;
        }

        public ActionResult Index()
        {
            //_commandHandler.Handle(new CreateDataProviderCommand(Guid.NewGuid(), "test"));

            var props = typeof (IvidResponse).GetPublicProperties().Select(x => new DataProviderFieldItemDto(x.Name, x.PropertyType.Name));


            return View(props);
        }

        public ActionResult Import()
        {

            return View();
        }
    }

    public class DataProviderFieldItemDto
    {
        public DataProviderFieldItemDto(string name, string type)
        {
            Name = name;
            Type = type;
        }

        public string Name { get; set; }
        public string Type { get; set; }
        public string Label { get; set; }
        public string Definition { get; set; }
        public string Industries { get; set; }

    }
}