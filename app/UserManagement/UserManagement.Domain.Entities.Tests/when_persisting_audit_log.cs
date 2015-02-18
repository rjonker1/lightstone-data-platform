using System;
using System.Linq;
using FluentNHibernate.Testing;
using NHibernate;
using UserManagement.Domain.Core.Repositories;
using UserManagement.TestHelper.BaseTests;
using UserManagement.TestHelper.Helpers;
using Xunit;
using Xunit.Extensions;

namespace UserManagement.Domain.Entities.Tests
{
    public class when_persisting_audit_log : when_persisting_entities_to_db
    {
        public override void Observe()
        {
            base.Observe();
        }

        [Observation]
        public void should_persist_Audit_Role()
        {
            var auditRepo = new Repository<AuditLog>(Session);
           
            var roleId = Guid.Parse("7C270960-0C16-4812-9CEF-275EA308A1AD");

            // create the role

            Session.BeginTransaction();

            var roleRepo = new Repository<Role>(Session);

            var role = new Role("TestRole " + roleId) {Id = roleId};

            roleRepo.SaveOrUpdate(role);

            Session.Transaction.Commit();

            Session.Evict(role);

            // assert exists in the audit log

            var exists = auditRepo.Where(a => a.RecordId == roleId && a.CommitVersion.Value == 1 && a.EventType == "A" && a.EntityName == "Role");

            //Assert.True(exists.Any());

            // Update

            Session = null;
            Session = Container.Resolve<ISessionFactory>().OpenSession();

            // fine the role and modify the role

            Session.BeginTransaction();

            roleRepo = new Repository<Role>(Session);
            role = roleRepo.Get(roleId);

            role.UpdateValue("TestRoleX");
            Session.Transaction.Commit();

            Session.Evict(role);

            auditRepo = new Repository<AuditLog>(Session);

            exists = auditRepo.Where(a => a.RecordId == roleId && a.CommitVersion.Value == 2 && a.EventType == "M" && a.EntityName == "Role");

            //Assert.True(exists.Any());
            
            // delete
            
            Session = null;

            Session = Container.Resolve<ISessionFactory>().OpenSession();

            roleRepo = new Repository<Role>(Session);
            role = roleRepo.Get(roleId);
            
            Session.BeginTransaction();
            roleRepo.Delete(role);
            Session.Transaction.Commit();

            auditRepo = new Repository<AuditLog>(Session);

            exists = auditRepo.Where(a => a.RecordId == roleId && a.CommitVersion.Value == 3 && a.EventType == "D" && a.EntityName == "Role");

           // Assert.True(exists.Any());


            // userType

            Session = null;

            Session = Container.Resolve<ISessionFactory>().OpenSession();

            var userTypeId = Guid.Parse("618115AF-799D-44DC-96BB-83073D3A1C28");

            // create the role

            Session.BeginTransaction();

            var userTypeRepo = new Repository<UserType>(Session);

            var userType = new UserType("TestUserType " + userTypeId) { Id = userTypeId };

            userTypeRepo.SaveOrUpdate(userType);

            Session.Transaction.Commit();

            Session.Evict(userType);

            // assert exists in the audit log

            exists = auditRepo.Where(a => a.RecordId == userTypeId && a.CommitVersion.Value == 1 && a.EventType == "A" && a.EntityName == "UserType");

            //Assert.True(exists.Any());

            // Update

            Session = null;
            Session = Container.Resolve<ISessionFactory>().OpenSession();

            // fine the role and modify the role

            Session.BeginTransaction();

            userTypeRepo = new Repository<UserType>(Session);
            userType = userTypeRepo.Get(userTypeId);

            userType.UpdateValue("TestUserTypeX");
            Session.Transaction.Commit();

            Session.Evict(userType);

            auditRepo = new Repository<AuditLog>(Session);

            exists = auditRepo.Where(a => a.RecordId == userTypeId && a.CommitVersion.Value == 2 && a.EventType == "M" && a.EntityName == "UserType");

            //Assert.True(exists.Any());

            // delete

            Session = null;

            Session = Container.Resolve<ISessionFactory>().OpenSession();

            userTypeRepo = new Repository<UserType>(Session);
            userType = userTypeRepo.Get(userTypeId);

            Session.BeginTransaction();
            userTypeRepo.Delete(userType);
            Session.Transaction.Commit();

            auditRepo = new Repository<AuditLog>(Session);

            exists = auditRepo.Where(a => a.RecordId == userTypeId && a.CommitVersion.Value == 3 && a.EventType == "D" && a.EntityName == "UserType");

//            Assert.True(exists.Any());
        }


        [Observation]
        public void should_persist_Audit_UserType()
        {
            var auditRepo = new Repository<AuditLog>(Session);

            
        }

    }
}
