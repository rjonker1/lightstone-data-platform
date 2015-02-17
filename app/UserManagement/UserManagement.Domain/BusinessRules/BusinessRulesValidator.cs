using UserManagement.Domain.Entities;

namespace UserManagement.Domain.BusinessRules
{
    public class BusinessRulesValidator
    {
     
        public void CheckRules(object enity)
        {

            if (enity is User)
            {
                //User rule reference
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