using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using DataPlatform.Shared.Repositories;
using NHibernate;
using NHibernate.Transform;
using Workflow.Billing.Domain.Entities;

namespace Workflow.Billing.Helpers.StoredProcedures
{
    public class StoredProcedure<T> : IStoredProcedure<StoredProcedure<T>>
    {
        private readonly ISession _session;

        public StoredProcedure(ISession session)
        {
            _session = session;
        }

        private string _query { get; set; }
        private Dictionary<string, string> _parameters { get; set; }

        public StoredProcedure<T> Query(string query)
        {
            _query = query;
            return this;
        }

        public StoredProcedure<T> WithParameters(Dictionary<string, string> queryParams)
        {
            _parameters = queryParams;
            return this;
        }

        public void Execute()
        {
            var query = _session.CreateSQLQuery(_query);

            foreach (var parameter in _parameters) 
                query.SetParameter(parameter.Key, parameter.Value);

            query.SetResultTransformer(Transformers.AliasToBean<StageBilling>());


        }

        public IEnumerable<T> Test()
        {
            var query = _session.CreateSQLQuery(_query);

            foreach (var parameter in _parameters)
                query.SetParameter(parameter.Key, parameter.Value);

            query.SetResultTransformer(Transformers.AliasToBean<T>());

            return query.List<T>();
        } 
    }
}