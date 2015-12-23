using System.Collections.Generic;
using System.Linq;
using Lim.Domain.Client;
using Lim.Domain.Client.Commands;
using Lim.Domain.Client.Handlers;
using Lim.Domain.Lookup.Commands;
using Lim.Domain.Push.Ftp.Database;
using Lim.Dtos;
using Nancy;
using Toolbox.LightstoneAuto.Domain.Base;

namespace Lim.Web.UI.Modules
{
    public class FtpDatabaseModule : NancyModule
    {
        public FtpDatabaseModule(IHandleGettingConfiguration setup, IHandleGettingIntegrationClient client, IReadDatabaseExtractFacade readDatabaseExtract)
        {
            Get["/integrations/for/ftp/database/configurations"] = _ => View["integrations/ftp/database/configurations", FtpDatabaseConfiguration.Get(client)];

            Get["/integrations/for/ftp/database/push"] = _ =>
            {
                var model = PushFtpDatabaseConfiguration.Create();
                model.SetFrequency(setup, new GetFrequencyTypes());
                model.SetWeekdays(setup, new GetWeekdays());
                model.SetIntegrationClients(client, new GetIntegrationClients());
                model.SetDatabaseExtracts(readDatabaseExtract.GetDataExtracts().Where(w => w.Activated).ToList());
                return View["/integrations/ftp/database/push", model];
            };

            Post["/integrations/for/ftp/database/push/save"] = _ =>
            {
                return Response.AsRedirect("/integrations/for/ftp/database/configurations");
            };
        }

        private static List<DatabaseExtractDto> GetDatabaseExtracts()
        {
            return new List<DatabaseExtractDto>();
        }
    }
}