using System;
using System.Collections.Generic;
using LightstoneApp.Domain.Core.Entities;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace LightstoneApp.Domain.Core.Tests
{
    /// <summary>
    ///     This is a test class for ChangeTrackerIteratorTest and is intended
    ///     to contain all ChangeTrackerIteratorTest Unit Tests
    /// </summary>
    [TestClass]
    public class ChangeTrackerIteratorTest
    {
        /// <summary>
        ///     A test for ChangeTrackerIterator Constructor
        /// </summary>
        [TestMethod]
        [DeploymentItem("LightstoneApp.Domain.Core.Entities.dll")]
        public void ChangeTrackerIterator_Constructor_Test()
        {
            var privateObject = new PrivateObject(typeof (ChangeTrackerIterator), null, null);
        }


        [TestMethod]
        public void ChangeTrackerIterator_InvokeCreateMethod_Test()
        {
            CreateTestHelper(GetFakeData());
        }

        [TestMethod]
        public void ChangeTrackerIterator_CheckGraph_Test()
        {
            //Arrange
            Master fake = GetFakeData();
            ChangeTrackerIterator iterator = ChangeTrackerIterator.Create(fake);

            //Act
            var privateObject = new PrivateObject(iterator);
            var items = (List<IObjectWithChangeTracker>) privateObject.GetField("_items");

            //Assert
            Assert.IsTrue(items.Count == 3);
            Assert.IsTrue(items.Contains(fake));
            Assert.IsTrue(items.Contains(fake.ToOne));
            Assert.IsTrue(items.Contains(fake.ToMany[0]));
        }


        /// <summary>
        ///     A test for Dispose
        /// </summary>
        [TestMethod]
        public void ChangeTrackerIterator_InvokeDispose_Test()
        {
            //arrange
            ChangeTrackerIterator actual;
            actual = ChangeTrackerIterator.Create(GetFakeData());

            var privateObject = new PrivateObject(actual);


            //act
            List<IObjectWithChangeTracker> items;
            items = (List<IObjectWithChangeTracker>) privateObject.GetField("_items");

            //assert
            Assert.IsTrue(items.Count > 0);

            //act
            actual.Dispose();
            items = (List<IObjectWithChangeTracker>) privateObject.GetField("_items");

            //assert
            Assert.IsTrue(items.Count == 0);
        }

        [TestMethod]
        public void ChangeTrackerStopAllTracking_Invoke_Test()
        {
            //arrange
            Master fake = GetFakeData();

            //act and assert


            fake.StopTrackingAll();


            Assert.IsFalse(fake.ChangeTracker.ChangeTrackingEnabled);
            Assert.IsFalse(fake.ToOne.ChangeTracker.ChangeTrackingEnabled);
            Assert.IsFalse(fake.ToMany[0].ChangeTracker.ChangeTrackingEnabled);
        }

        [TestMethod]
        public void ChangeTrackerStartAllTracking_Invoke_Test()
        {
            //arrange
            Master fake = GetFakeData();

            //act and assert


            fake.StartTrackingAll();

            Assert.IsTrue(fake.ChangeTracker.ChangeTrackingEnabled);
            Assert.IsTrue(fake.ToOne.ChangeTracker.ChangeTrackingEnabled);
            Assert.IsTrue(fake.ToMany[0].ChangeTracker.ChangeTrackingEnabled);
        }

        [TestMethod]
        public void ChangeTrackerAcceptAllChanges_Invoke_Test()
        {
            //arrange
            Master fake = GetFakeData();

            //act and assert

            fake.AcceptAllChanges();

            Assert.IsTrue(fake.ChangeTracker.State == ObjectState.Unchanged);
            Assert.IsTrue(fake.ToOne.ChangeTracker.State == ObjectState.Unchanged);
            Assert.IsTrue(fake.ToMany[0].ChangeTracker.State == ObjectState.Unchanged);
        }


        [TestMethod]
        public void ChangeTrackerMergeWith_Invoke_Test()
        {
            //Arrange
            Master master = GetFakeData();

            //Act

            var newToOne = new DetailOneToOne
            {
                DetailOneToOneId = 1
            };
            master.ToOne = newToOne.MergeWith(master, (dto1, dto2) => dto1.DetailOneToOneId == dto2.DetailOneToOneId);

            //Assert
            Assert.IsFalse(ReferenceEquals(master.ToOne, newToOne));

            master.ToOne = null;

            master.ToOne = newToOne.MergeWith(master, (dto1, dto2) => dto1.DetailOneToOneId == dto2.DetailOneToOneId);

            Assert.IsTrue(ReferenceEquals(master.ToOne, newToOne));
        }

        #region Helper Methods

        /// <summary>
        ///     A test for Create
        /// </summary>
        public void CreateTestHelper<TEntity>(TEntity entity)
            where TEntity : IObjectWithChangeTracker
        {
            ChangeTrackerIterator actual;
            actual = ChangeTrackerIterator.Create(entity);
            Assert.IsNotNull(actual);
        }

        private static Master GetFakeData()
        {
            var manyDetail = new TrackableCollection<DetailToMany>();
            manyDetail.Add(new DetailToMany {DetailToManyId = 1});
            var master = new Master
            {
                MasterId = 1,
                ToOne = new DetailOneToOne
                {
                    DetailOneToOneId = 1
                },
                ToMany = manyDetail
            };
            return master;
        }

        #endregion

        #region Nested Classes

        public class DetailOneToOne : IObjectWithChangeTracker
        {
            public int DetailOneToOneId { get; set; }

            #region IObjectWithChangeTracker Members

            private readonly ObjectChangeTracker tracker = new ObjectChangeTracker();

            public ObjectChangeTracker ChangeTracker
            {
                get { return tracker; }
            }

            #endregion
        }

        public class DetailToMany : IObjectWithChangeTracker
        {
            public int DetailToManyId { get; set; }

            #region IObjectWithChangeTracker Members

            private readonly ObjectChangeTracker tracker = new ObjectChangeTracker();

            public ObjectChangeTracker ChangeTracker
            {
                get { return tracker; }
            }

            #endregion
        }

        public class Master : IObjectWithChangeTracker
        {
            public int MasterId { get; set; }

            public DetailOneToOne ToOne { get; set; }

            public TrackableCollection<DetailToMany> ToMany { get; set; }

            #region IObjectWithChangeTracker Members

            private readonly ObjectChangeTracker tracker = new ObjectChangeTracker();

            public ObjectChangeTracker ChangeTracker
            {
                get { return tracker; }
            }

            #endregion
        }

        #endregion
    }
}