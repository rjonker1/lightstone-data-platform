﻿using System;
using System.Data.Entity;

namespace LightstoneApp.Infrastructure.CrossCutting.NetFramework.EventSourcing
{
    public class EventStoreDbContext : DbContext
    {
        public const string SchemaName = "Events";

        public EventStoreDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Event>()
                .HasKey(x => new {x.AggregateId, x.AggregateType, x.Version})
                .ToTable("Events", SchemaName);
        }
    }

    public class Event
    {
        public Guid AggregateId { get; set; }
        public string AggregateType { get; set; }
        public int Version { get; set; }
        public string Payload { get; set; }
        public string CorrelationId { get; set; }

        // TODO: Following could be very useful for when rebuilding the read model from the event store, 
        // to avoid replaying every possible event in the system
        // public string EventType { get; set; }
    }
}
