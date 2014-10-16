using System;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using Microsoft.Practices.Unity;
using Rhino.Mocks;

namespace LightstoneApp.Infrastructure.CrossCutting.IoC.Unity.Helper
{
    public class AutoMockingUnityContainer : UnityContainer
    {
        private readonly MockRepository _mocks;

        public AutoMockingUnityContainer()
        {
            _mocks = new MockRepository();
        }
        
        public static AutoMockingUnityContainer Configure()
        {
            var result = new AutoMockingUnityContainer();

            ObjectProvider.Container = result;

            return result;
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
         SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillReturnAStubFor <T>() where T : class
        {
            return (AutoMockingUnityContainer) this.RegisterType(typeof (T),
                                                                 new StubFactory(typeof (T), _mocks, MockLifetime.Singleton));
        }
        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
        SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillReturnAStubFor<T>(params object[] parameters) where T : class
        {
            return (AutoMockingUnityContainer)this.RegisterType(typeof(T),
                                                                 new StubFactory(typeof(T), _mocks, MockLifetime.Singleton,parameters));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
         SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillReturnAStubFor <T>(string mapName) where T : class
        {
            return (AutoMockingUnityContainer) this.RegisterType(typeof (T), mapName,
                                                                 new StubFactory(typeof (T), _mocks, MockLifetime.Singleton));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
        SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillCreateMockFor <T>() where T : class
        {
            return (AutoMockingUnityContainer) this.RegisterType(typeof (T),
                                                                 new MockFactory(typeof (T), _mocks, MockLifetime.Singleton));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
        SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillCreateMockFor<T>(string mapName) where T : class
        {
            return (AutoMockingUnityContainer)this.RegisterType(typeof(T), mapName, new MockFactory(typeof(T), _mocks, MockLifetime.Singleton));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
         SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillCreatePartialMockFor <T>(MockLifetime lifetime) where T : class
        {
            return (AutoMockingUnityContainer) this.RegisterType(typeof (T),
                                                                 new PartialMockFactory(typeof (T), _mocks, lifetime));
        }

        [SuppressMessage("Microsoft.Reliability", "CA2000:Dispose objects before losing scope"),
        SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public AutoMockingUnityContainer WillCreateMockFor<T>(params object[] parameters) where T : class
        {
            return (AutoMockingUnityContainer)this.RegisterType(typeof(T),
                                                                 new MockFactory(typeof(T), _mocks, MockLifetime.Singleton, parameters));
        }

        /// <summary>
        ///   Starts the replay mode for the mocking test
        /// </summary>
        public void ReplayAll()
        {
            _mocks.ReplayAll();
        }

        /// <summary>
        ///   Verifies that the recorded mocks were replayed as expected
        /// </summary>
        public void VerifyAll()
        {
            _mocks.VerifyAll();
        }

        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public T DynamicMock <T>() where T : class
        {
            return _mocks.DynamicMock <T>();
        }

        #region Nested type: AbstractFactory

        private abstract class AbstractFactory : ContainerControlledLifetimeManager
        {
            protected readonly MockLifetime Lifetime;

            protected readonly MockRepository Mocks;
            protected readonly Type TheType;

            protected AbstractFactory(Type theType, MockRepository mocks, MockLifetime lifetime)
            {
                TheType = theType;
                Lifetime = lifetime;
                Mocks = mocks;
            }

            protected abstract object GetTheObject(Type type);

            public override object GetValue()
            {
                object value = base.GetValue();
                if (Lifetime == MockLifetime.NewEveryTime || value == null)
                {
                    value = GetTheObject(TheType);
                    SetValue(value);
                }

                return value;
            }
        }

        #endregion

        #region Nested type: MockFactory

        private class MockFactory : AbstractFactory
        {
            private readonly object[] _parameters;
            public MockFactory(Type theType, MockRepository mocks,
                               MockLifetime lifetime)
                : base(theType, mocks, lifetime)
            {
            }

            public MockFactory(Type theType, MockRepository mocks,
                            MockLifetime lifetime,params object[] parameters)
                : base(theType, mocks, lifetime)
            {
                _parameters = parameters;
            }

            protected override object GetTheObject(Type type)
            {
                if (_parameters != null)
                    return Mocks.StrictMock(type, _parameters);
                return Mocks.StrictMock(type);
                
            }
            protected  object GetTheObject(Type type,params object[] obj)
            {
                return Mocks.StrictMock(type,obj);

            }
        }

        #endregion

        #region Nested type: PartialMockFactory

        private class PartialMockFactory : AbstractFactory
        {
            public PartialMockFactory(Type theType, MockRepository mocks,
                                      MockLifetime lifetime)
                : base(theType, mocks, lifetime)
            {
            }

            protected override object GetTheObject(Type type)
            {
                return Mocks.PartialMock(TheType);
            }
        }

        #endregion

        #region Nested type: StubFactory

        private class StubFactory : AbstractFactory
        {
            private readonly object[] _parameters;
            public StubFactory(Type theType, MockRepository mocks, MockLifetime lifetime)
                : base(theType, mocks, lifetime)
            {
            }

            /// <summary>
            /// overload on constructor to allwo for default parameters
            /// </summary>
            /// <param name="theType"></param>
            /// <param name="mocks"></param>
            /// <param name="lifetime"></param>
            /// <param name="parameters"></param>
            public StubFactory(Type theType, MockRepository mocks, MockLifetime lifetime, params object[] parameters)
                : base(theType, mocks, lifetime)
            {
                _parameters = parameters;
            }

            protected override object GetTheObject(Type type)
            {
                if (_parameters != null)
                    return Mocks.Stub(type, _parameters);
                return Mocks.Stub(type);
            }

            /// <summary>
            /// additional method ot allow for non default constructor injection
            /// </summary>
            /// <param name="type"></param>
            /// <param name="parameters"></param>
            /// <returns></returns>
            protected object GetTheObject(Type type,params object[] parameters)
            {
                return Mocks.Stub(type,parameters);
            }
        }

        #endregion

        public T ResolveWithConstructorParameters<T>(params object[] parameterOverrides)
        {

                try
                {
                    var overridesArray = parameterOverrides
                                .Select(p => new DependencyOverride(p.GetType(), p))
                               .ToArray();
                    return this.Resolve<T>(null, overridesArray); //null needed to avoid a StackOverflow :)

                }
                catch
                {
                    return default(T);
                }
            }
       


        
    }

    public enum MockLifetime
    {
        Singleton,
        NewEveryTime
    }
}