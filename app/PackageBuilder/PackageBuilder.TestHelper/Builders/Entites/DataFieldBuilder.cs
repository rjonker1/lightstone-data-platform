using DataPlatform.Shared.Entities;
using PackageBuilder.Domain.DataFields.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class DataFieldBuilder
    {
        private string _name;
        private IDataProvider _dataProvider;
        public IDataField Build()
        {
            return new DataField(_name, null);
        }

        public DataFieldBuilder With(string name)
        {
            _name = name;
            return this;
        }

        public DataFieldBuilder With(IDataProvider dataProvider)
        {
            _dataProvider = dataProvider;
            return this;
        }
    }
}