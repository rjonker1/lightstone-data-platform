using PackageBuilder.Domain.Entities;
using PackageBuilder.Domain.Entities.DataFields.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class ActionBuilder
    {
        private string _name = "";
        private readonly Criteria _criteria = new Criteria();
        public IAction Build()
        {
            return new Action(_name)
            {
                Criteria = _criteria
            };
        }

        public ActionBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public ActionBuilder With(params IDataField[] fields)
        {
            _criteria.Fields = fields;
            return this;
        }
    }
}