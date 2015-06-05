
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class UserMappingOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.HasManyToMany(x => x.Roles).Cascade.SaveUpdate().Table("UserRole");
            mapping.HasManyToMany(x => x.Customers).Cascade.SaveUpdate().Table("CustomerUser");
            mapping.HasMany(x => x.ClientUsers).Cascade.SaveUpdate().Table("ClientUser");
            mapping.HasManyToMany(x => x.UserAliases).Cascade.SaveUpdate();
        }
    }

    //Mapping not required if circular reference is removed

    ////Need RoleMappingOverride mapping override, to allow unique entries into the intermediary table (UserRole)!
    ////Default: Overwrites the entry in the UserRole table if only the UserMappingOverride is specified 
    //public class RoleMappingOverride : IAutoMappingOverride<Role>
    //{
    //    public void Override(AutoMapping<Role> mapping)
    //    {
    //        //mapping.HasManyToMany(x => x.Users).Inverse().Table("UserRole").ParentKeyColumn("RoleId").ChildKeyColumn("UserId");
    //    }
    //}
}
