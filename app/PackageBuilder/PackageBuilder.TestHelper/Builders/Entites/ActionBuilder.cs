using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class ActionBuilder
    {
        public static IAction Get(string name, params IDataField[] fields)
        {
            return new Action(name)
            {
                Criteria = new Criteria
                {
                    Fields = fields
                }
            };
        }
    }
}