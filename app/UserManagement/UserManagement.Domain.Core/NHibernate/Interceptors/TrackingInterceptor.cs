using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using NHibernate;
using NHibernate.Transaction;
using NHibernate.Type;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities;
//using IsolationLevel = System.Data.IsolationLevel;

namespace UserManagement.Domain.Core.NHibernate.Interceptors
{
    public class TrackingInterceptor : EmptyInterceptor
    {
        private TransactionSynchronization _transactionSynchronization;
        private ISession session = null;

        public bool ChangedTracked { get; set; }

        private class TransactionSynchronization : ISynchronization
        {
            public TransactionSynchronization(TrackingInterceptor trackingInterceptor)
            {
                this.TrackingInterceptor = trackingInterceptor;
            }

            private TrackingInterceptor TrackingInterceptor { get; set; }

            public void BeforeCompletion()
            {
                // TODO: find previous commits for the record
            }

            public ISession Session { get; set; }
            public IEnumerable<AuditLog> AuditLogs { get; set; }
            //public string EntityState { get; set; }
            public object Entity { get; set; }
            public Guid EntityId { get; set; }

            public void AfterCompletion(bool success)
            {
                if (!success) return;

                LogAudits(Session, AuditLogs);
            }


            private void LogAudits(ISession session, IEnumerable<AuditLog> logs)
            {
                session.SessionFactory.OpenSession();

                session.BeginTransaction(IsolationLevel.RepeatableRead);

                var auditLogRepository = new Repository<AuditLog>(session);

                var commitSequence = 0;

                // TODO: find previous commits for the record

                var previousAudidtsCommitVersion = auditLogRepository.Where(x => x.RecordId == EntityId).OrderByDescending(o => o.CommitVersion).Select(s => s.CommitVersion.Value).Distinct().FirstOrDefault();

                var commitVersion = 1;

                commitVersion = commitVersion + previousAudidtsCommitVersion;

                foreach (var auditLog in logs)
                {
                    if (auditLog.EventType == "D")
                    {
                        auditLog.NewValue = null;
                    }

                    if (auditLog.EventType == "A")
                    {
                        auditLog.OriginalValue = null;
                    }

                    if (auditLog.NewValue != auditLog.OriginalValue)
                    {
                        auditLog.CommitVersion = commitVersion;
                        auditLog.CommitSequence = commitSequence;
                        commitSequence++;
                        auditLogRepository.SaveOrUpdate(auditLog);
                    }
                }

                session.Transaction.Commit();

                TrackingInterceptor.ChangedTracked = false;
            }
        }


        public override void SetSession(ISession session)
        {
            this.session = session;
            base.SetSession(session);
        }


        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames,
           IType[] types)
        {
            //Footprint(entity, currentState, propertyNames);

            GetChanges(entity, id, currentState, previousState, propertyNames, types, "A");

            return null;
        }

        private void GetChanges(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames,
            IType[] types, string state)
        {

            if(ChangedTracked) return;

            if (entity.GetType() == typeof(AuditLog))
            {
                return;
            }

            var ordinal = 0;
            var commitId = Guid.NewGuid();
            var recordId = Guid.Parse(id.ToString());
            var sessionAuditLogs = new List<AuditLog>(propertyNames.Length);

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

                if (currentState != null && currentState[ordinal] != null)
                {
                    newValue = currentState[ordinal];
                }

                var auditLog = new AuditLog(commitId)
                {
                    Id = Guid.NewGuid(),
                    EntityName = entity.GetType().Name,
                    FieldName = propertyName,
                    OriginalValue = originalValue as string,
                    NewValue = newValue as string,
                    RecordId = recordId,
                    DataType = types[ordinal].Name
                };

                var time = DateTime.Now;

                auditLog.Created = time;
                auditLog.EventDateUtc = time;
                auditLog.Modified = time;
                auditLog.CommitSequence = ordinal;
                auditLog.CommitVersion = 0;
                auditLog.Revertable = true;

                if (auditLog.OriginalValue == auditLog.NewValue)
                {
                    if (auditLog.OriginalValue == null && auditLog.NewValue == null)
                    {
                        ordinal++;
                        break;
                    }

                    auditLog.EventType = "A";
                }

                if (auditLog.OriginalValue == null && auditLog.NewValue != null)
                {
                    auditLog.EventType = "A";
                }

                if (auditLog.OriginalValue != null && auditLog.NewValue != null)
                {
                    if (auditLog.OriginalValue != auditLog.NewValue)
                    {
                        auditLog.EventType = "M";
                    }
                    ;
                }

                if (auditLog.NewValue == null && auditLog.OriginalValue != null)
                {
                    auditLog.EventType = "D";
                }

                sessionAuditLogs.Add(auditLog);

                ordinal++;
            }

            AuditObjectModification(entity, id, sessionAuditLogs);
        }

        public override void OnDelete(object entity, object id, object[] state, string[] propertyNames, IType[] types)
        {
            Footprint(entity, state, propertyNames);
            GetChanges(entity, id, null, state, propertyNames, types, "D");

            base.OnDelete(entity, id, state, propertyNames, types);
        }

        private void AuditObjectModification(object entity, object id, IEnumerable<AuditLog> sessionAuditLogs)
        {
           // session.SessionFactory.OpenSession();

            if (ChangedTracked) return;

            _transactionSynchronization = new TransactionSynchronization(this)
            {
                Session = session,
                AuditLogs = sessionAuditLogs,
                Entity = entity,
                EntityId = Guid.Parse(id.ToString())
            };

            session.Transaction.RegisterSynchronization(_transactionSynchronization);

            ChangedTracked = true;
        }


        public override bool OnSave(object entity, object id, object[] state,
            string[] propertyNames,
            global::NHibernate.Type.IType[] types)
        {
            Footprint(entity, state, propertyNames);

            //GetChanges(entity, id, state, null, propertyNames, types, "A");

            return base.OnSave(entity, id, state, propertyNames, types);
        }

        private void Footprint(object entity, object[] state, string[] propertyNames)
        {
            var time = DateTime.Now;
            var identity = System.Security.Principal.WindowsIdentity.GetCurrent();
            var userName = "System";
            var typedEntity = (Entity)entity;

            if (identity != null)
            {
                userName = identity.Name;
            }

            if (typedEntity.Created == null)
            {
                typedEntity.Created = time;
                typedEntity.CreatedBy = userName;
            }

            typedEntity.Modified = time;
            typedEntity.ModifiedBy = userName;

            var indexOfCreated = GetIndex(propertyNames, "Created");
            var indexOfCreatedBy = GetIndex(propertyNames, "CreatedBy");
            var indexOfModified = GetIndex(propertyNames, "Modified");
            var indexOfModifiedBy = GetIndex(propertyNames, "ModifiedBy");

            if (state[indexOfCreated] == null)
            {
                state[indexOfCreated] = time;
                state[indexOfCreatedBy] = userName;
            }

            state[indexOfModified] = time;
            state[indexOfModifiedBy] = userName;
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState,
            object[] previousState, string[] propertyNames,
            IType[] types)
        {
            //session.SessionFactory.OpenSession();

            Footprint(entity, currentState, propertyNames);

            GetChanges(entity, id, currentState, previousState, propertyNames, types, "M");

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
