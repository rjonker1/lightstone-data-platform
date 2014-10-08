using System.Collections.Generic;
using System.Data.Entity.Core.Objects;
using LightstoneApp.Infrastructure.Data.Core.Extensions;
using LightstoneApp.Infrastructure.Data.Core.Fakes;

namespace LightstoneApp.Infrastructure.Data.Core.Tests.StubAndFakes
{
    /// <summary>
    ///     UnitOfWork stub for test a GenericRepository base class
    /// </summary>
    public class UnitOfWorkStub
        : StubIQueryableUnitOfWork
    {
        #region Members

        private static List<Entity> entityList;

        #endregion

        #region Constructor

        /// <summary>
        ///     Default constructor for this unit of work stub.
        ///     This constructor prepare stub with fake contents
        /// </summary>
        public UnitOfWorkStub()
        {
            PrepareStub();
        }

        #endregion

        #region Private Methods

        private void PrepareStub()
        {
            //List prepare fake object set

            entityList = new List<Entity>
            {
                new Entity {Id = 1, Field = "field 1"},
                new Entity {Id = 2, Field = "field 2"},
                new SubEntity {Id = 3, Field = "field 3"}
            };

            MemorySet<Entity> fakeObjectSet = entityList.ToMemorySet();

            //Assign this object set when CreateObjectSet<Entity> is executed!
            CreateSetOf1(() => fakeObjectSet as IObjectSet<Entity>);
            //this.CreateSet<Entity>(() => fakeObjectSet as IObjectSet<Entity>);

            //prepare ApplyChanges stub 

            RegisterChangesOf1M0<Entity>(item =>
            {
                int index = entityList.IndexOf(item);
                if (index != -1)
                    entityList[index] = item;
                else
                    entityList.Add(item);
            });

            //this.RegisterChangesTEntity<Entity>((item) =>
            //                               {
            //                                   int index = entityList.IndexOf(item);
            //                                   if (index != -1)
            //                                       entityList[index] = item;
            //                                   else
            //                                       entityList.Add(item);
            //                               });
        }

        #endregion
    }
}