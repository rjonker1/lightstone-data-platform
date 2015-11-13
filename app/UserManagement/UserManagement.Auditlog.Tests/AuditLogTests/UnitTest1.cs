using System;
using Castle.Windsor;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NHibernate;
using UserManagement.Api.Installers;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
using UserManagement.TestHelper;
using UserManagement.TestHelper.Helpers;

namespace AuditLogTests
{


   // [TestClass]
    public class UnitTest1
    {
        private readonly IWindsorContainer _container = new WindsorContainer();
        private ISession _session;

       // [TestInitialize]
        public void IntializaTest()
        {
            _container.Kernel.ComponentModelCreated += OverrideHelper.OverrideContainerLifestyle;

            // Container.Kernel.ComponentModelCreated += OverrideHelper.OverrideNhibernateSessionLifestyle;

            _container.Install(new NHibernateInstaller());
            OverrideHelper.OverrideNhibernateCfg(_container);

            _session = _container.Resolve<ISession>();
        }

        public void CleanupTest()
        {
            _session.Dispose();
        }


     //   [TestMethod]
        public void TestAddRole()
        {
            

            // create the role

            _session.BeginTransaction();

            var roleRepo = new Repository<Role>(_session);

            var roleId = Guid.Parse("7C270960-0C16-4812-9CEF-275EA308A1AD");

            var role = new Role("TestRole " + roleId);

            role.Id = roleId;

            roleRepo.SaveOrUpdate(role);

            _session.Transaction.Commit();
          
          
        }

       // [TestMethod]
        public void TestModifyRole()
        {
            var roleRepo = new Repository<Role>(_session);
            var roleId = Guid.Parse("7C270960-0C16-4812-9CEF-275EA308A1AD");

            // fine the role and modify the role

            _session.BeginTransaction();

            var role1 = roleRepo.Get(roleId);

            role1.UpdateValue("TestRoleX");
            _session.Transaction.Commit();
        }

        //[TestMethod]
        public void TestDeleteRole()
        {
            var roleRepo = new Repository<Role>(_session);

            var roleId = Guid.Parse("7C270960-0C16-4812-9CEF-275EA308A1AD");

            // fine the role and modify the role
            var role1 = roleRepo.Get(roleId);
        
            // delete
            _session.BeginTransaction();
            roleRepo.Delete(role1);
            _session.Transaction.Commit();

        }
    }
}
