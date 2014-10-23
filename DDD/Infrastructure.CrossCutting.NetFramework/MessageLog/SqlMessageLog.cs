using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Messaging;
using LightstoneApp.Infrastructure.CrossCutting.NetFramework.Serialization;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.MessageLog
{
    public class SqlMessageLog : IEventLogReader
    {
        private readonly string _nameOrConnectionString;
        private readonly IMetadataProvider _metadataProvider;
        private readonly ITextSerializer _serializer;

        public SqlMessageLog(string nameOrConnectionString, ITextSerializer serializer,
            IMetadataProvider metadataProvider)
        {
            _nameOrConnectionString = nameOrConnectionString;
            _serializer = serializer;
            _metadataProvider = metadataProvider;
        }

        public void Save(IEvent @event)
        {
            using (var context = new MessageLogDbContext(_nameOrConnectionString))
            {
                IDictionary<string, string> metadata = _metadataProvider.GetMetadata(@event);

                context.Set<MessageLogEntity>().Add(new MessageLogEntity
                {
                    Id = Guid.NewGuid(),
                    SourceId = @event.SourceId.ToString(),
                    Kind = metadata[StandardMetadata.Kind],
                    AssemblyName = metadata[StandardMetadata.AssemblyName],
                    FullName = metadata[StandardMetadata.FullName],
                    Namespace = metadata[StandardMetadata.Namespace],
                    TypeName = metadata[StandardMetadata.TypeName],
                    SourceType = metadata[StandardMetadata.SourceType],
                    CreationDate = DateTime.UtcNow.ToString("o"),
                    Payload = _serializer.Serialize(@event),
                });
                context.SaveChanges();
            }
        }

        public void Save(ICommand command)
        {
            using (var context = new MessageLogDbContext(_nameOrConnectionString))
            {
                IDictionary<string, string> metadata = _metadataProvider.GetMetadata(command);

                context.Set<MessageLogEntity>().Add(new MessageLogEntity
                {
                    Id = Guid.NewGuid(),
                    SourceId = command.Id.ToString(),
                    Kind = metadata[StandardMetadata.Kind],
                    AssemblyName = metadata[StandardMetadata.AssemblyName],
                    FullName = metadata[StandardMetadata.FullName],
                    Namespace = metadata[StandardMetadata.Namespace],
                    TypeName = metadata[StandardMetadata.TypeName],
                    SourceType = metadata[StandardMetadata.SourceType],
                    CreationDate = DateTime.UtcNow.ToString("o"),
                    Payload = _serializer.Serialize(command),
                });
                context.SaveChanges();
            }
        }

        public IEnumerable<IEvent> Query(QueryCriteria criteria)
        {
            return new SqlQuery(_nameOrConnectionString, _serializer, criteria);
        }

        private class SqlQuery : IEnumerable<IEvent>
        {
            private readonly string nameOrConnectionString;
            private readonly ITextSerializer serializer;
            private readonly QueryCriteria _criteria;

            public SqlQuery(string nameOrConnectionString, ITextSerializer serializer, QueryCriteria criteria)
            {
                this.nameOrConnectionString = nameOrConnectionString;
                this.serializer = serializer;
                this._criteria = criteria;
            }

            public IEnumerator<IEvent> GetEnumerator()
            {
                return new DisposingEnumerator(this);
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }

            private class DisposingEnumerator : IEnumerator<IEvent>
            {
                private readonly SqlQuery _sqlQuery;
                private MessageLogDbContext _context;
                private IEnumerator<IEvent> _events;

                public DisposingEnumerator(SqlQuery sqlQuery)
                {
                    _sqlQuery = sqlQuery;
                }

                ~DisposingEnumerator()
                {
                    if (_context != null) _context.Dispose();
                }

                public void Dispose()
                {
                    if (_context != null)
                    {
                        _context.Dispose();
                        _context = null;
                        GC.SuppressFinalize(this);
                    }
                    if (_events != null)
                    {
                        _events.Dispose();
                    }
                }

                public IEvent Current
                {
                    get { return _events.Current; }
                }

                object IEnumerator.Current
                {
                    get { return Current; }
                }

                public bool MoveNext()
                {
                    if (_context == null)
                    {
                        _context = new MessageLogDbContext(_sqlQuery.nameOrConnectionString);
                        IQueryable<MessageLogEntity> queryable = _context.Set<MessageLogEntity>().AsQueryable()
                            .Where(x => x.Kind == StandardMetadata.EventKind);

                        Expression<Func<MessageLogEntity, bool>> where = _sqlQuery._criteria.ToExpression();
                        if (where != null)
                            queryable = queryable.Where(where);

                        _events = queryable
                            .AsEnumerable()
                            .Select(x => _sqlQuery.serializer.Deserialize<IEvent>(x.Payload))
                            .GetEnumerator();
                    }

                    return _events.MoveNext();
                }

                public void Reset()
                {
                    throw new NotSupportedException();
                }
            }
        }
    }
}
