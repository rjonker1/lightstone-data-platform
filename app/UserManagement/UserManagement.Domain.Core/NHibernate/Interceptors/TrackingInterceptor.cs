using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NHibernate;
using NHibernate.Event.Default;
using NHibernate.Id;
using NHibernate.Transaction;
using NHibernate.Type;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;

namespace UserManagement.Domain.Core.NHibernate.Interceptors
{
    public class TrackingInterceptor : EmptyInterceptor
    {
        public class TransactionSynchronization : ISynchronization
        {
            private readonly Action _action;

            public TransactionSynchronization(Action action)
            {
                _action = action;
            }

            public void BeforeCompletion()
            {

            }

            public void AfterCompletion(bool success)
            {
                if (success)
                    _action();
            }
        }

        private ISession session = null;
        //private AuditLog _auditLog;

        private Repository<AuditLog> _auditLogRepository;

        private List<AuditLog> _sessionAuditLogs;

        public override void SetSession(ISession session)
        {
            _auditLogRepository = new Repository<AuditLog>(session);

            _sessionAuditLogs = new List<AuditLog>();


            this.session = session;
            base.SetSession(session);
        }


        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames,
           IType[] types)
        {

            if (entity.GetType() == typeof(AuditLog))
            {
                return new[] { 0 };
            }

            session.SessionFactory.OpenSession();
            

            _sessionAuditLogs = new List<AuditLog>();

            var dirtyObjectIds = base.FindDirty(entity, id, currentState, previousState, propertyNames, types);

            var ordinal = 0;

            foreach (var propertyName in propertyNames)
            {
                object originalValue = null;

                if (previousState != null)
                {
                    if (previousState[ordinal] != null)
                    {
                        originalValue = previousState[ordinal];
                    }
                }


                object newValue = null;

                if (currentState[ordinal] != null)
                {
                    newValue = currentState[ordinal];
                }


                var auditLog = new AuditLog(Guid.NewGuid())
                {
                    EntityName = entity.GetType().Name,
                    FieldName = propertyName,
                    OriginalValue = originalValue as string,
                    NewValue = newValue as string
                };

                _sessionAuditLogs.Add(auditLog);



                ordinal++;

            }

            return dirtyObjectIds;

        }

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            AuditObjectModification(entity, id, EntityState.Deleted);

            base.OnDelete(entity, id, state, propertyNames, types);
        }

        private void AuditObjectModification(object entity, object id, EntityState state)
        {

            session.Transaction.RegisterSynchronization(new TransactionSynchronization(() =>
            {

                // TODO: submit message to the bus here!


                // TODO: persite the AuditLog session


                session.Transaction.Begin();

                foreach (var log in _sessionAuditLogs)
                {

                    


                    
                }

                

                session.Transaction.Commit();

                _sessionAuditLogs.Clear();

            })); 


        }


        public override bool OnSave(object entity, object id, object[] state,
            string[] propertyNames,
            global::NHibernate.Type.IType[] types)
        {

            // AuditObjectModification(entity, id, EntityState.Persistent);



            var time = DateTime.Now;

            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();

            var userName = "System";

            if (identity != null)
            {
                userName = identity.Name;
            }


            var typedEntity = (Entity)entity;
            typedEntity.Created = time;
            typedEntity.CreatedBy = userName;
            typedEntity.Modified = time;
            typedEntity.ModifiedBy = userName;

            var indexOfCreated = GetIndex(propertyNames, "Created");
            var indexOfCreatedBy = GetIndex(propertyNames, "CreatedBy");
            var indexOfModified = GetIndex(propertyNames, "Modified");
            var indexOfModifiedBy = GetIndex(propertyNames, "ModifiedBy");

            state[indexOfCreated] = time;
            state[indexOfCreatedBy] = userName;
            state[indexOfModified] = time;
            state[indexOfModifiedBy] = userName;


            AuditObjectModification(entity, id, EntityState.Persistent);
            return base.OnSave(entity, id, state, propertyNames, types);
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState,
            object[] previousState, string[] propertyNames,
            global::NHibernate.Type.IType[] types)
        {
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();

            var userName = "System";

            if (identity != null)
            {
                userName = identity.Name;
            }

            var time = DateTime.Now;

            var indexOfCreated = GetIndex(propertyNames, "Created");
            var indexOfCreatedBy = GetIndex(propertyNames, "CreatedBy");
            var indexOfModified = GetIndex(propertyNames, "Modified");
            var indexOfModifiedBy = GetIndex(propertyNames, "ModifiedBy");

            var typedEntity = (Entity)entity;
            if (typedEntity.Created == DateTime.MinValue)
            {
                currentState[indexOfCreated] = time;
                currentState[indexOfCreatedBy] = userName;
                typedEntity.Created = time;
                typedEntity.CreatedBy = userName;
            }

            currentState[indexOfModified] = time;
            currentState[indexOfModifiedBy] = userName;
            typedEntity.Modified = time;
            typedEntity.ModifiedBy = userName;

            AuditObjectModification(entity, id, EntityState.Transient);

            return base.OnFlushDirty(entity, id, currentState, previousState, propertyNames, types);
        }

        private int GetIndex(object[] array, string property)
        {
            for (var i = 0; i < array.Length; i++)
                if (array[i].ToString() == property)
                    return i;

            return -1;
        }

    }
}
