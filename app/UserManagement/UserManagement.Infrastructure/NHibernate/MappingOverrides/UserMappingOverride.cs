
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class UserMappingOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.HasManyToMany(x => x.Roles).Cascade.All().Table("UserRole").ParentKeyColumn("UserId").ChildKeyColumn("RoleId");
        }
    }

    //public class RoleMappingOverride : IAutoMappingOverride<Role>
    //{
    //    public void Override(AutoMapping<Role> mapping)
    //    {
    //        mapping.HasManyToMany(x => x.Users).Cascade.All().Table("UserRole").ParentKeyColumn("RoleId").ChildKeyColumn("UserId");
    //    }
    //}
}
