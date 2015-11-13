using System;
using System.Linq;
using NHibernate;
using NHibernate.Proxy;

namespace UserManagement.Domain.Core.NHibernate.Interceptors
{
    public static class SessionExtensions
    {
        public static Boolean IsDirtyEntity(this ISession session, Object entity)
        {
            var sessionImpl = session.GetSessionImplementation();

            var persistenceContext = sessionImpl.PersistenceContext;

            var oldEntry = persistenceContext.GetEntry(entity);

            var className = oldEntry.EntityName;

            var persister = sessionImpl.Factory.GetEntityPersister(className);


            if ((oldEntry == null) && (entity is INHibernateProxy))
            {

                var proxy = entity as INHibernateProxy;

                var obj = sessionImpl.PersistenceContext.Unproxy(proxy);

                oldEntry = sessionImpl.PersistenceContext.GetEntry(obj);
            }


            var oldState = oldEntry.LoadedState;

            var currentState = persister.GetPropertyValues(entity, sessionImpl.EntityMode);

            var dirtyProps = oldState.Select((o, i) => (oldState[i] == currentState[i]) ? -1 : i).Where(x => x >= 0).ToArray();

            return (dirtyProps != null);
        }


        public static Boolean IsDirtyProperty(this ISession session, Object entity, String propertyName)
        {
            var sessionImpl = session.GetSessionImplementation();

            var persistenceContext = sessionImpl.PersistenceContext;

            var oldEntry = persistenceContext.GetEntry(entity);

            var className = oldEntry.EntityName;

            var persister = sessionImpl.Factory.GetEntityPersister(className);


            if ((oldEntry == null) && (entity is INHibernateProxy))
            {

                var proxy = entity as INHibernateProxy;

                var obj = sessionImpl.PersistenceContext.Unproxy(proxy);

                oldEntry = sessionImpl.PersistenceContext.GetEntry(obj);
            }


            var oldState = oldEntry.LoadedState;

            var currentState = persister.GetPropertyValues(entity, sessionImpl.EntityMode);

            var dirtyProps = persister.FindDirty(currentState, oldState, entity, sessionImpl);

            var index = Array.IndexOf(persister.PropertyNames, propertyName);

            var isDirty = (dirtyProps != null) ? (Array.IndexOf(dirtyProps, index) != -1) : false;

            return (isDirty);

        }

        public static Object GetOriginalEntityProperty(this ISession session, Object entity, String propertyName)
        {
            var sessionImpl = session.GetSessionImplementation();

            var persistenceContext = sessionImpl.PersistenceContext;

            var oldEntry = persistenceContext.GetEntry(entity);

            var className = oldEntry.EntityName;

            var persister = sessionImpl.Factory.GetEntityPersister(className);


            if ((oldEntry == null) && (entity is INHibernateProxy))
            {
                var proxy = entity as INHibernateProxy;

                Object obj = sessionImpl.PersistenceContext.Unproxy(proxy);

                oldEntry = sessionImpl.PersistenceContext.GetEntry(obj);
            }


            var oldState = oldEntry.LoadedState;

            var currentState = persister.GetPropertyValues(entity, sessionImpl.EntityMode);

            var dirtyProps = persister.FindDirty(currentState, oldState, entity, sessionImpl);

            var index = Array.IndexOf(persister.PropertyNames, propertyName);

            var isDirty = (dirtyProps != null) ? (Array.IndexOf(dirtyProps, index) != -1) : false;

            return ((isDirty == true) ? oldState[index] : currentState[index]);
        }
    }
}