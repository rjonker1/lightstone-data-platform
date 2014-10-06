using LightstoneApp.Domain.Core.Entities;

namespace LightstoneApp.Infrastructure.Data.Core.Tests.StubAndFakes
{
    /// <summary>
    ///     Simple class for support GenericRepositoryTest fixtures
    /// </summary>
    internal class Entity : IObjectWithChangeTracker
    {
        #region Properties

        public int Id { get; set; }
        public string Field { get; set; }

        #endregion

        #region Constructor

        public Entity()
        {
            changeTracker = new ObjectChangeTracker();
        }

        #endregion

        #region IObjectWithChangeTracker Members

        private readonly ObjectChangeTracker changeTracker;

        public ObjectChangeTracker ChangeTracker
        {
            get { return changeTracker; }
        }

        #endregion
    }
}