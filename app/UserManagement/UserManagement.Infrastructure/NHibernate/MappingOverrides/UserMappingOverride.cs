
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
            mapping.HasManyToMany(x => x.Customers).Cascade.All().Table("UserLinkedToCustomer").ParentKeyColumn("UserId").ChildKeyColumn("CustomerId");
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
