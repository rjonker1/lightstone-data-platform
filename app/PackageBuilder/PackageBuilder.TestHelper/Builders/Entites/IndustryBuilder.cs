using System;
using PackageBuilder.Domain.Entities.Industries.WriteModels;

namespace PackageBuilder.TestHelper.Builders.Entites
{
    public class IndustryBuilder
    {
        private Guid? _id;
        private string _name;
        public Industry Build()
        {
            return new Industry(_id ?? Guid.NewGuid(), _name);
        }

        public IndustryBuilder With(Guid id)
        {
            _id = id;
            return this;
        }

        public IndustryBuilder With(string name)
        {
            _name = name;
            return this;
        }
    }
}