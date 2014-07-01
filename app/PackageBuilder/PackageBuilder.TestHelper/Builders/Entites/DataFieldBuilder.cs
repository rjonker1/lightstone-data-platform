using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.Entities;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataFieldBuilder
    {
        private string _name;
        private IDataSource _source;
        public IDataField Build()
        {
            return new DataField(_name) { DataSource = _source, Type = typeof(string).ToString() };
        }

        public DataFieldBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public DataFieldBuilder With(IDataSource source)
        {
            _source = source;
            return this;
        }
    }
}