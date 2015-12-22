using System;
using System.Collections.Generic;
using System.Threading;
using Lim.Core;
using Lim.Dtos;
using Lim.Enums;
using Nancy;
using Nancy.ModelBinding;
using Toolbox.LightstoneAuto.Domain.Base;
using Toolbox.LightstoneAuto.Domain.Commands.Dataset;
using Toolbox.LightstoneAuto.Domain.Commands.View;
using Toolbox.LightstoneAuto.Factories;

namespace Lim.Web.UI.Modules
{
    public class DatabaseExtractModule : NancyModule
    {
        private readonly Guid _correlationId;

        public DatabaseExtractModule(IReadDatabaseExtractFacade readDatabaseExtract, IReadDatabaseViewFacade readDatabaseView, ISendCommand commandSender)
        {
            _correlationId = Guid.NewGuid();


            Get["/database/lsauto/extracts"] = _ =>
            {
                var model = readDatabaseExtract.GetDataExtracts();
                return View["database/lsautoextracts", model];
            };

            Get["/database/lsauto/import/views"] = _ =>
            {
                var views = new BuildViewDtoFactory().Build(Guid.Empty);
                foreach (var view in views)
                {
                    var existingView = readDatabaseView.GetDatabaseView(view.Name);
                    if (existingView != null && existingView.Name == view.Name)
                    {
                        var modify = new ModifyView(existingView, Context.CurrentUser.UserName, existingView.Version, _correlationId);
                        commandSender.Send(modify);
                        continue;
                    }

                    view.AggregateId = Guid.NewGuid();
                    var command = new LoadView(view, Context.CurrentUser.UserName, _correlationId);
                    commandSender.Send(command);
                }
              
                return Response.AsRedirect("/database/lsauto/extracts");
            };

            Get["/database/lsauto/extract/edit/{id}"] = _ =>
            {
                long id;
                long.TryParse(_.Id, out id);
                if (id == 0) return HttpStatusCode.BadRequest;

                var model = readDatabaseExtract.GetDataExtract(id);
                if (model == null) return HttpStatusCode.BadRequest;
                return View["database/lsautoextract", model];
            };

            Post["/database/lsauto/extract/save"] = _ =>
            {
                var dto = this.Bind<DatabaseExtractDto>();
                dto.Fields = new List<DatabaseExtractFieldDto>();

                for (var i = 0; i < dto.FieldCount; i++)
                {
                    var field = string.Format("Fields[{0}].", i);
                    dto.Fields.Add(new DatabaseExtractFieldDto
                    {
                        Id = long.Parse(Request.Form[field + "Id"]),
                        Name = Request.Form[field + "Name"],
                        DatabaseExtractId = dto.Id,
                        DisplayName = Request.Form[field + "DisplayName"],
                        Selected = Request.Form[field + "Selected"]
                    });
                }

                dto.Source = Source.UserIntiated;
                commandSender.Send(new ModifyDataExtract(dto, Context.CurrentUser.UserName, dto.Version, _correlationId));
               
                Thread.Sleep(2000);
                return Response.AsRedirect("/database/lsauto/extracts");
            };
        }
    }
}