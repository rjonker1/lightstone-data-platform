using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Nancy.Session;
using NHibernate;
using NHibernate.Transaction;
using NHibernate.Type;
using UserManagement.Domain.Core.Entities;
using UserManagement.Domain.Core.Repositories;
using UserManagement.Domain.Entities.BusinessRules;
using ISession = NHibernate.ISession;

namespace UserManagement.Domain.Entities.NHibernate.Interceptors
{
    public class TrackingInterceptor : EmptyInterceptor
    {
        private TransactionSynchronization _transactionSynchronization;
        private ISession _session;

        private class TransactionSynchronization : ISynchronization
        {
            public TransactionSynchronization(TrackingInterceptor trackingInterceptor)
            {
                TrackingInterceptor = trackingInterceptor;
            }

            private TrackingInterceptor TrackingInterceptor { get; set; }

            public void BeforeCompletion()
            {
                // TODO: find previous commits for the record
               
            }

            public ISession Session { private get; set; }
            public List<AuditLog> AuditLogs { private get; set; }

            public object Entity { get; set; }

            public Guid EntityId { private get; set; }

            public void AfterCompletion(bool success)
            {
                if (!success) return;

                LogAudits();
            }


            private void LogAudits()
            {
                var session = Session;

                var logs = AuditLogs;

                session.SessionFactory.OpenSession();

                session.BeginTransaction(IsolationLevel.RepeatableRead);

                var auditLogRepository = new Repository<AuditLog>(session);

                var commitSequence = 0;

                // find previous commits for the record

                var firstLogSet = auditLogRepository.Where(x => x.RecordId == EntityId
                    && x.EventType == "A" && x.CommitVersion == 1);


                var previousAudidtsCommitVersion = auditLogRepository.Where(x => x.RecordId == EntityId)
                    .OrderByDescending(o => o.CommitVersion).Distinct().FirstOrDefault();

                var commitVersion = 1;

                var logsToExclude = new List<AuditLog>();


                if (previousAudidtsCommitVersion != null)
                {
                    if (previousAudidtsCommitVersion.CommitVersion != null)
                        commitVersion = commitVersion + previousAudidtsCommitVersion.CommitVersion.Value;

                    var firstLogSetList = firstLogSet.ToList();

                    foreach (var l1 in logs)
                    {
                        // exclude duplicate "A" records
                        logsToExclude.AddRange(firstLogSetList.Where(l2 => l1.EventType == "A" 
                            && l2.EventType == "A")
                            .Where(l2 => l1.CommitVersion == 1)
                            .Distinct().Select(l2 => l1));
                    }
                }

                foreach (var auditLog in logs.Except(logsToExclude))
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
                session.Evict(Entity);
            }
        }


        public override void SetSession(ISession session)
        {
            _session = session;
            base.SetSession(session);
        }


        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames,
           IType[] types)
        {
            GetChanges(entity, id, currentState, previousState, propertyNames, types, "A");

            return null;
        }

        private void GetChanges(object entity, object id, IList<object> currentState, IList<object> previousState, ICollection<string> propertyNames,
            IList<IType> types, string state)
        {
            if (entity.GetType() == typeof(AuditLog))
            {
                return;
            }

            var ordinal = 0;
            var commitId = Guid.NewGuid();
            var recordId = Guid.Parse(id.ToString());
            var sessionAuditLogs = new List<AuditLog>(propertyNames.Count);

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

        private void AuditObjectModification(object entity, object id, List<AuditLog> sessionAuditLogs)
        {
            _transactionSynchronization = new TransactionSynchronization(this)
            {
                Session = _session,
                AuditLogs = sessionAuditLogs,
                Entity = entity,
                EntityId = Guid.Parse(id.ToString())
            };

            _session.Transaction.RegisterSynchronization(_transactionSynchronization);
        }


        public override bool OnSave(object entity, object id, object[] state,
            string[] propertyNames,
            IType[] types)
        {

            //var brv = new BusinessRulesValidator();
            //brv.CheckRules(entity);

            Footprint(entity, state, propertyNames);

            return base.OnSave(entity, id, state, propertyNames, types);
        }

        //public override void BeforeTransactionCompletion(ITransaction tx)
        //{
        //    tx.Rollback();
        //    base.BeforeTransactionCompletion(tx);
        //}

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


            state[indexOfCreated] = time;
            state[indexOfCreatedBy] = userName;


            state[indexOfModified] = time;
            state[indexOfModifiedBy] = userName;
        }

        public override bool OnFlushDirty(object entity, object id, object[] currentState,
            object[] previousState, string[] propertyNames,
            IType[] types)
        {
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
