using System;
using System.Web.Mvc;
using PackageBuilder.Domain.Commands;

namespace PackageBuilder.Web.Controllers
{
    public class DataProviderController : Controller
    {
        private readonly IHandleCommand _commandHandler;

        public DataProviderController(IHandleCommand commandHandler)
        {
            _commandHandler = commandHandler;
        }

        public ActionResult Index()
        {
            _commandHandler.Handle(new CreateDataProviderCommand(Guid.NewGuid(), "test"));
            return View();
        }

        public ActionResult Import()
        {

            return View();
        }
    }
}