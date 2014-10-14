using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Reflection;
using Microsoft.Practices.Unity;

namespace LightstoneApp.Infrastructure.CrossCutting.IoC.Unity.Helper
{
    /// <summary>
    ///   Returns an Object instance as configured in the Configuration file for Unity
    /// </summary>
    public static class ObjectProvider
    {
        private static readonly object PadLock = new object();
        public static UnityContainer Container { get; set; }

        /// <summary>
        /// Gets a value indicating whether [use mocking].
        /// </summary>
        /// <value><c>true</c> if [use mocking]; otherwise, <c>false</c>.</value>
        private static bool UseMocking
        {
            get
            {
                lock (PadLock)
                {
                    try
                    {
                        string mockFlag = ConfigurationManager.AppSettings["UseMocking"];
                        if (string.IsNullOrEmpty(mockFlag)) return false;
                        bool returnValue;
                        return Boolean.TryParse(mockFlag, out returnValue) && returnValue;
                    }
                    catch
                    {
                        return false;
                    }
                }
            }
        }

        private static void Initialise()
        {
            if (Container == null)
            {
                lock (PadLock)
                {
                    if (Container == null)
                    {
                        Container = new UnityContainer();
                        ReplaceBehaviourExtensionsWithSafeExtension(Container);
                    }
                }
            }
        }

        /// <summary>
        ///   Creates the type sent in, and returns that created object
        /// </summary>
        // Known issue for factory creation methods - you get this error message. Suppressed.
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T GiveMeA<T>()
        {
            lock (PadLock)
            {
                Initialise();

                try
                {
                    return Container.Resolve<T>();
                }
                catch
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        ///   Creates the type sent in, and returns that created object
        /// </summary>
        // Known issue for factory creation methods - you get this error message. Suppressed.
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T GiveMeA<T>(params object[] parameterOverrides)
        {
            lock (PadLock)
            {
                Initialise();
                try
                {
                    Container.RegisterType<T>(new InjectionConstructor(parameterOverrides));
                    return Container.Resolve<T>();
                }
                catch
                {
                    return default(T);
                }
            }
        }

        /// <summary>
        ///   Creates the type sent in with the mapping name specified, and returns that created
        ///   object
        /// </summary>
        // Known issue with factory methods - same as above
        [SuppressMessage("Microsoft.Design", "CA1004:GenericMethodsShouldProvideTypeParameter")]
        public static T GiveMeA<T>(string mappingName)
        {
            lock (PadLock)
            {
                Initialise();
                return Container.Resolve<T>(mappingName);
            }
        }

        /// <summary>
        ///   Registers the type.
        /// </summary>
        /// <typeparam name = "T">Interface to map to</typeparam>
        /// <typeparam name = "TK">The concrete type to use.</typeparam>
        /// >
        /// <param name = "mappingName">Mapping name to use</param>
        public static void RegisterType<T, TK>(string mappingName) where TK : T
        {
            lock (PadLock)
            {
                if (!UseMocking)
                {
                    InitialiseContainer();

                    if (!Container.IsRegistered(typeof (T), mappingName))
                        Container.RegisterType<T, TK>(mappingName, new TransientLifetimeManager());
                }
            }
        }

        /// <summary>
        ///   Registers the type.
        /// </summary>
        /// <typeparam name = "T">Interface to map to</typeparam>
        /// <typeparam name = "TK">The concrete type to use.</typeparam>
        public static void RegisterType<T, TK>() where TK : T
        {
            lock (PadLock)
            {
                if (!UseMocking)
                {
                    InitialiseContainer();

                    if (!Container.IsRegistered(typeof (T)))
                        Container.RegisterType<T, TK>(new TransientLifetimeManager());
                }
            }
        }

        /// <summary>
        ///   Registers the type.
        /// </summary>
        /// <typeparam name = "T">Interface to map to</typeparam>
        /// <typeparam name = "TK">The concrete type to use.</typeparam>
        public static void RegisterType<T, TK>(bool singleton) where TK : T
        {
            lock (PadLock)
            {
                if (!UseMocking)
                {
                    InitialiseContainer();

                    if (!Container.IsRegistered(typeof (T)))
                    {
                        if (singleton)
                            Container.RegisterType<T, TK>(new ContainerControlledLifetimeManager());
                        else
                            Container.RegisterType<T, TK>(new TransientLifetimeManager());
                    }
                }
            }
        }

        /// <summary>
        ///   Registers the type.
        /// </summary>
        public static void RegisterType(Type fromType, Type toType, bool singleton)
        {
            lock (PadLock)
            {
                if (!UseMocking)
                {
                    InitialiseContainer();

                    if (!Container.IsRegistered(fromType))
                    {
                        if (singleton)
                            Container.RegisterType(fromType, toType, new ContainerControlledLifetimeManager());
                        else
                            Container.RegisterType(fromType, toType, new TransientLifetimeManager());
                    }
                }
            }
        }


        public static void RegisterInstance(Type type, object instance)
        {
            lock (PadLock)
            {
                if (!UseMocking)
                {
                    InitialiseContainer();
                    Container.RegisterInstance(type, instance, new ContainerControlledLifetimeManager());
                }
            }
        }

        public static bool IsRegistered(Type type)
        {
            return Container.IsRegistered(type);
        }

        public static bool IsRegistered<T>()
        {
            return IsRegistered(typeof (T));
        }

        public static bool IsRegistered(Type type, string mappingName)
        {
            var isRegistered = false;

            try
            {
                isRegistered = Container.IsRegistered(type, mappingName);
            }
            catch (Exception)
            {
                // nothing
            }
            return isRegistered;
        }

        public static bool IsRegistered<T>(string mappingName)
        {
            return IsRegistered(typeof (T), mappingName);
        }

        /// <summary>
        ///   Initialises the container.
        /// </summary>
        private static void InitialiseContainer()
        {
            lock (PadLock)
            {
                if (Container != null) return;
                Container = new UnityContainer();
                ReplaceBehaviourExtensionsWithSafeExtension(Container);
            }
        }

        public static IUnityContainer CreateChildContainer()
        {
            lock (PadLock)
            {
                return Container.CreateChildContainer();
            }
        }

        public static IUnityContainer InstallCoreExtensions(this IUnityContainer container)
        {
            container.RemoveAllExtensions();
            container.AddExtension(new UnityClearBuildPlanStrategies());
            container.AddExtension(new UnitySafeBehaviorExtension());


#pragma warning disable 612,618
            container.AddExtension(new InjectedMembers());
#pragma warning restore 612,618


            container.AddExtension(new UnityDefaultStrategiesExtension());

            return container;
        }

        public static void ReplaceBehaviourExtensionsWithSafeExtension(IUnityContainer container)
        {
            var extensionsField = container.GetType().GetField("extensions", BindingFlags.Instance | BindingFlags.NonPublic);
            if (extensionsField != null)
            {
                var extensionsList = (List<UnityContainerExtension>) extensionsField.GetValue(container);
                var existingExtensions = extensionsList.ToArray();
                container.RemoveAllExtensions();

                container.AddExtension(new UnitySafeBehaviorExtension());
                foreach (var extension in existingExtensions)
                {
                    if (!(extension is UnityDefaultBehaviorExtension))
                    {
                        container.AddExtension(extension);
                    }
                }
            }
        }

        #region Nested type: UnityClearBuildPlanStrategies

        /// <summary>
        /// Implements a <see cref="UnityContainerExtension"/> that clears the list of 
        /// build plan strategies held by the container.
        /// </summary>
        public class UnityClearBuildPlanStrategies : UnityContainerExtension
        {
            protected override void Initialize()
            {
                Context.BuildPlanStrategies.Clear();
            }
        }

        #endregion
    }
}