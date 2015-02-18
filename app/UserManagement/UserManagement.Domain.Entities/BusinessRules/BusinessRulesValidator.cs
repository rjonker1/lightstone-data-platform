using UserManagement.Domain.Entities.BusinessRules.Users;

namespace UserManagement.Domain.Entities.BusinessRules
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