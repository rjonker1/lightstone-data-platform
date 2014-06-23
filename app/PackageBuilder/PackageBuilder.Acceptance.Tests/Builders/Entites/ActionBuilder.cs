using DataPlatform.Shared.Entities;
using PackageBuilder.Domain;

namespace PackageBuilder.Acceptance.Tests.Builders.Entites
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