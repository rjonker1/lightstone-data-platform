
using FluentNHibernate.Automapping;
using FluentNHibernate.Automapping.Alterations;
using UserManagement.Domain.Entities;

namespace UserManagement.Infrastructure.NHibernate.MappingOverrides
{
    public class UserMappingOverride : IAutoMappingOverride<User>
    {
        public void Override(AutoMapping<User> mapping)
        {
            mapping.References(x => x.UserType).Cascade.All();
            mapping.HasManyToMany(x => x.Roles).Cascade.All().Table("UserRole");
            mapping.HasManyToMany(x => x.Customers).Cascade.All().Table("CustomerUser");

            //mapping.HasMany(x => x.ClientUsers).Cascade.All().KeyColumn("UserId");
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
