using DataPlatform.Shared.Repositories;
using Nancy;
using Nancy.Responses.Negotiation;
using Workflow.Billing.Domain.Entities;

namespace Billing.Api.Modules
{
    public class AdminBillingModule : NancyModule
    {
        public AdminBillingModule(IRepository<AuditLog> auditLogs)
        {

            Get["/Admin/Billing"] = _ =>  Negotiate.WithView("Index");
            Get["/Admin/AuditLog"] = _ =>
            {
                return Negotiate
                    .WithView("AuditLog")
                    .WithMediaRangeModel(MediaRange.FromString("application/json"), new { data = auditLogs });
            };
        }
    }
}