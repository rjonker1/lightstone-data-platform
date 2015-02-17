using UserManagement.Domain.BusinessRules.Users;
using UserManagement.Domain.Entities;

namespace UserManagement.Domain.BusinessRules
{
    public class BusinessRulesValidator
    {
     
        public void CheckRules(object enity)
        {

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

        }
    }
}