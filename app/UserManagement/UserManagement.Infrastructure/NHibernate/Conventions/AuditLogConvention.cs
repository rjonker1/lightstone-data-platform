using FluentNHibernate.Conventions;
using FluentNHibernate.Conventions.AcceptanceCriteria;
using FluentNHibernate.Conventions.Inspections;
using FluentNHibernate.Conventions.Instances;

namespace UserManagement.Infrastructure.NHibernate.Conventions
{
    public class AuditLogConvention : IPropertyConvention, IPropertyConventionAcceptance
    {
        public void Accept(IAcceptanceCriteria<IPropertyInspector> criteria)
        {
            criteria.Expect(x => x.Type == typeof(string)).Expect(x => x.Length == 0);
        }
        public void Apply(IPropertyInstance instance)
        {

            if (instance.EntityType.Name == "AuditLog")
                instance.Length(10000);


            //if (instance.Name == "OriginalValue")
            //{
            //    instance.Length(10000);
            //}

            //if (instance.Name == "NewValue")
            //{
            //    instance.Length(10000);
            //}


        }
    }
}