using DataPlatform.Shared.Public.Entities;

namespace PackageBuilder.Api.Entities
{
    public class Action : NamedEntity, IAction
    {
        public Action(string name)
            : base(name)
        {
        }
    }
}