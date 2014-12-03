using System;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class IndustryBuilder
    {
        private string _name;
        private bool _selected;
        public Industry Build()
        {
            return new Industry(Guid.NewGuid(), _name, _selected);
        }

        public IndustryBuilder With(Guid id)
        {
            return this;
        }

        public IndustryBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}