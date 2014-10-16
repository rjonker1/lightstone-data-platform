using System;
using System.Linq;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using LightstoneApp.Infrastructure.Data.Core.Requests;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace LightstoneApp.Infrastructure.Data.Core.Indexes
{
    public class History_Stream_Aggregation : AbstractMultiMapIndexCreationTask<History_Stream_Aggregation.MomentCloud>
    {
        public enum MomentType
        {
            Event,
            Command,
            Response,
            Exception
        }

        public History_Stream_Aggregation()
        {
            AddMap<Commit>(docs => from doc in docs
                from evt in doc.Events
                select new
                {
                    Count = 1,
                    MomentType = MomentType.Event,
                });

            AddMap<CommandRequest>(docs => from doc in docs
                let command = doc.Command
                select new
                {
                    Count = 1,
                    MomentType = MomentType.Command,
                });

            AddMap<CommandResponse>(docs => from doc in docs
                let response = doc.Response
                select new
                {
                    Count = 1,
                    MomentType = MomentType.Response,
                });

            AddMap<CommandException>(docs => from doc in docs
                let error = doc.Error
                select new
                {
                    Count = 1,
                    MomentType = MomentType.Exception,
                });

            Reduce = results => from result in results
                group result by result.MomentType
                into g
                select new
                {
                    MomentType = g.Key,
                    Count = g.Sum(e => e.Count)
                };

            StoreAllFields(FieldStorage.Yes);
        }

        public class MomentCloud
        {
            public Int32 Count { get; private set; }
            public MomentType MomentType { get; private set; }
        }
    }
}