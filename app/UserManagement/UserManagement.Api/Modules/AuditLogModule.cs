using System.Linq;
using Nancy;
using Nancy.Responses.Negotiation;
using Shared.BuildingBlocks.Api.Security;
using UserManagement.Domain.Entities;
using UserManagement.Infrastructure.Repositories;

namespace UserManagement.Api.Modules
{
    public class AuditLogModule : SecureModule
    {
        public AuditLogModule(IRepository<AuditLog> auditlogs)
        {

            Get["/AuditLogs"] = _ => 
                Negotiate
                .WithView("Index")
                .WithMediaRangeModel(MediaRange.FromString("application/json"), new
                {
                    data = auditlogs.OrderByDescending( o=> o.EventDateUtc).Take(100)
                });
        }
    }
}