//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Linq;
//using DataPlatform.Shared.Repositories;
//using NHibernate;
//using NHibernate.Transform;
//using Workflow.Billing.Domain.Entities;

//namespace Workflow.Billing.Helpers.StoredProcedures
//{
//    public class StoredProcedure//<T> : IStoredProcedure<StoredProcedure<T>>
//    {
//        private readonly ISession _session;

//        public StoredProcedure(ISession session)
//        {
//            _session = session;
//        }

//        private string _query { get; set; }
//        private Dictionary<string, string> _parameters { get; set; }

//        public StoredProcedure Query(string query)
//        {
//            _query = query;
//            return this;
//        }

//        public StoredProcedure WithParameters(Dictionary<string, string> queryParams)
//        {
//            _parameters = queryParams;
//            return this;
//        }

//        public IEnumerable<StageBilling> RetrieveData()
//        {
//            var query = _session.CreateSQLQuery(_query);

//            foreach (var parameter in _parameters)
//                query.SetParameter(parameter.Key, parameter.Value);

//            query.SetResultTransformer(Transformers.AliasToBean<StageBilling>());

//            return query.List<StageBilling>();
//        }
//    }
//}