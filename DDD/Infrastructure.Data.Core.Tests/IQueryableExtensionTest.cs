using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Infrastructure.Data.Core.Extensions;
using LightstoneApp.Infrastructure.Data.Core.Tests.StubAndFakes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Infrastructure.Data.Core.Tests
{
    [TestClass]
    public class IQueryableExtensionTest
    {
        [ExpectedException(typeof (ArgumentNullException))]
        public void IncludeWithPath_Invoke_NullPathThrowArgumentNullException()
        {
            //Arrange
            var entities = new List<Entity>
            {
                new Entity {Id = 0, Field = "field"}
            };

            MemorySet<Entity> objectSet = entities.ToMemorySet();

            //Act
            ((IQueryable<Entity>) objectSet).Include((string) null);
        }
        [ExpectedException(typeof (ArgumentNullException))]
        public void IncludeWithMemberExpression_Invoke_NullPathThrowArgumentNullException()
        {
            //Arrange
            var entities = new List<Entity>
            {
                new Entity {Id = 0, Field = "field"}
            };

            MemorySet<Entity> objectSet = entities.ToMemorySet();

            //Act
            objectSet.Include((Expression<Func<Entity, object>>) null);
        }
        public void IncludeWithPath_Invoke()
        {
            //Arrange
            var entities = new List<Entity>
            {
                new Entity {Id = 0, Field = "field"}
            };

            MemorySet<Entity> objectSet = entities.ToMemorySet();
            string includePath = "Field";
            //Act
            ((IQueryable<Entity>) objectSet).Include(includePath);

            //Assert
            var actual = new PrivateObject(objectSet).GetField("_IncludePaths") as List<string>;
            Assert.IsTrue(actual.Where(s => s == includePath).Count() == 1);
        }
        public void IncludeWithMemberExpression_Invoke()
        {
            //Arrange
            var entities = new List<Entity>
            {
                new Entity {Id = 0, Field = "field"}
            };

            MemorySet<Entity> objectSet = entities.ToMemorySet();
            Expression<Func<Entity, object>> navigationExpression = t => t.Field;
            //Act
            objectSet.Include(navigationExpression);

            //Assert
            var actual = new PrivateObject(objectSet).GetField("_IncludePaths") as List<string>;
            Assert.IsTrue(actual.Where(s => s == "Field").Count() == 1);
        }
    }
}