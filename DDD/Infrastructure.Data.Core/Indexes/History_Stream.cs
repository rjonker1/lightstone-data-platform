using System;
using System.Linq;
using LightstoneApp.Infrastructure.Data.Core.Commits;
using LightstoneApp.Infrastructure.Data.Core.Requests;
using Raven.Abstractions.Indexing;
using Raven.Client.Indexes;

namespace LightstoneApp.Infrastructure.Data.Core.Indexes
{
    public class History_Stream : AbstractMultiMapIndexCreationTask<History_Stream.Moment>
    {
        public enum MomentType
        {
            Event,
            Command,
            Response,
            Exception
        }

        public History_Stream()
        {
            AddMap<Commit>(docs => from doc in docs
                from evt in doc.Events
                select new
                {
                    evt.Id,
                    doc.CreatedOn,
                    doc.AggregateIdentifier,
                    doc.CorrelationId,
                    doc.UserAccount,
                    Type = AsDocument(evt).Value<string>("$type"),
                    Data = evt,
                    MomentType = MomentType.Event,
                });

            AddMap<CommandRequest>(docs => from doc in docs
                let command = doc.Command
                select new
                {
                    doc.Id,
                    doc.CreatedOn,
                    AggregateIdentifier = "",
                    doc.CorrelationId,
                    doc.UserAccount,
                    Type = AsDocument(command).Value<string>("$type"),
                    Data = command,
                    MomentType = MomentType.Command,
                });

            AddMap<CommandResponse>(docs => from doc in docs
                let response = doc.Response
                select new
                {
                    doc.Id,
                    doc.CreatedOn,
                    AggregateIdentifier = "",
                    doc.CorrelationId,
                    doc.UserAccount,
                    Type = AsDocument(response).Value<string>("$type"),
                    Data = response,
                    MomentType = MomentType.Response,
                });

            AddMap<CommandException>(docs => from doc in docs
                let error = doc.Error
                select new
                {
                    doc.Id,
                    doc.CreatedOn,
                    AggregateIdentifier = "",
                    doc.CorrelationId,
                    doc.UserAccount,
                    Type = AsDocument(error).Value<string>("$type"),
                    Data = error,
                    MomentType = MomentType.Exception,
                });

            StoreAllFields(FieldStorage.Yes);
        }

        public class Moment
        {
            public String Id { get; private set; }
            public DateTimeOffset CreatedOn { get; private set; }
            public String AggregateIdentifier { get; private set; }
            public String CorrelationId { get; private set; }
            public String UserAccount { get; private set; }
            public String Type { get; private set; }
            public Object Data { get; private set; }
            public MomentType MomentType { get; private set; }
        }
    }
}