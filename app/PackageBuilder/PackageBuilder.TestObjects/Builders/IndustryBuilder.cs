using System;
using PackageBuilder.Domain.Entities.Industries.Read;

namespace PackageBuilder.TestObjects.Builders
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