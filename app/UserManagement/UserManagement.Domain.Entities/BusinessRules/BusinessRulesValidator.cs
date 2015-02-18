using System.Collections;
using System.Linq;
using DataPlatform.Shared.ExceptionHandling;
using DataPlatform.Shared.Helpers.Extensions;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities.BusinessRules.Users;

namespace UserManagement.Domain.Entities.BusinessRules
{
    public class BusinessRulesValidator
    {
        public void CheckRules(object enity, IRepository<Entity> entityRepo)
        {


            //foreach (Entity entity in entityRepo)
            //{
            //}

            if (enity is User)
            {
                var userRule = new CreateUpdateUserRule();
                userRule.Apply();
            }
            else if (enity is Customer)
            {
                //Customer rule reference
            }
            else if (enity is Client)
            {
                //Client rule reference
            }
            else if (enity is Package)
            {
                //Package rule reference

                //if (entityRepo.Get().Contains(enity as Entity))
                //{
                    var exception = new LightstoneAutoException("Package Reference already exists".FormatWith(enity.GetType().Name));
                    this.Warn(() => exception);
                    throw exception;
                //}

            }

        }
    }
}