using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using NHibernate;
using NHibernate.Event.Default;
using NHibernate.Id;
using NHibernate.Type;
using UserManagement.Domain.Core.Entities;

namespace UserManagement.Domain.Core.NHibernate.Interceptors
{
    public class TrackingInterceptor : EmptyInterceptor
    {
        public override int[] FindDirty(object entity, object id, object[] currentState, object[] previousState, string[] propertyNames,
           IType[] types)
        {

            var dirtyObjectIds = base.FindDirty(entity, id, currentState, previousState, propertyNames, types);

            foreach (var propertyName in propertyNames)
            {

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

            //var indexOfCreated = GetIndex(propertyNames, "Created");
            //var indexOfCreatedBy = GetIndex(propertyNames, "CreatedBy");
            //var indexOfModified = GetIndex(propertyNames, "Modified");
            //var indexOfModifiedBy = GetIndex(propertyNames, "ModifiedBy");

            var typedEntity = (Entity)entity;
            //if (typedEntity.Created == DateTime.MinValue)
            //{
            //    currentState[indexOfCreated] = time;
            //    currentState[indexOfCreatedBy] = userName;
            //    typedEntity.Created = time;
            //    typedEntity.CreatedBy = userName;
            //}

            //currentState[indexOfModified] = time;
            //currentState[indexOfModifiedBy] = userName;
            //typedEntity.Modified = time;
            //typedEntity.ModifiedBy = userName;

            AuditObjectModification(entity, id, EntityState.Persistent);

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
