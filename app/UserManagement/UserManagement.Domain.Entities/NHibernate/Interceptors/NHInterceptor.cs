using NHibernate;

namespace UserManagement.Domain.Entities.NHibernate.Interceptors
{
    public class NhInterceptor: EmptyInterceptor
    {

        //public override bool OnSave(object entity, object id, object[] state, string[] propertyNames, global::NHibernate.Type.IType[] types)
        //{
        //    var brv = new BusinessRulesValidator();
        //    brv.CheckRules(entity);

        //    return base.OnSave(entity, id, state, propertyNames, types);
        //}
    }
}