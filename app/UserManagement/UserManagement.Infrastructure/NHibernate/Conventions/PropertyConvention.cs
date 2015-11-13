using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.Instances;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class PropertyConvention : IPropertyConvention
    {
        public void Apply(IPropertyInstance instance)
        {
            if (instance.Name == "Name")
                instance.Length(255);
        }
    }
}
