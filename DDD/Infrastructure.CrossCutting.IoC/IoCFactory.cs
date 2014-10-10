using System.ComponentModel;
using LightstoneApp.Infrastructure.CrossCutting.IoC.Unity;

namespace LightstoneApp.Infrastructure.CrossCutting.IoC
{
    /// <summary>
    ///     IoCFactory  implementation
    /// </summary>
    public sealed class IoCFactory
    {
        #region Singleton

        private static readonly IoCFactory instance = new IoCFactory();

        /// <summary>
        ///     Get singleton instance of IoCFactory
        /// </summary>
        public static IoCFactory Instance
        {
            get { return instance; }
        }

        #endregion

        #region Members

        private readonly IContainer _currentContainer;

        /// <summary>
        ///     Get current configured IContainer
        ///     <remarks>
        ///         At this moment only IoCUnityContainer exists
        ///     </remarks>
        /// </summary>
        public IContainer CurrentContainer
        {
            get { return _currentContainer; }
        }

        #endregion

        #region Constructor

        /// <summary>
        ///     Only for singleton pattern, remove before field init IL anotation
        /// </summary>
        static IoCFactory()
        {
        }

        private IoCFactory()
        {
            _currentContainer = new IoCUnityContainer();
        }

        #endregion
    }
}