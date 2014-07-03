using System;
using System.Linq;
using EventStore.ClientAPI;
using EventTracking.Domain.Core;
using EventTracking.Measurement;
using EventTracking.Measurement.Lace.Events;
using EventTracking.Measurement.Lace.Projections;
using Xunit.Extensions;

namespace EventTracking.Acceptence.Tests
{
    public class when_reading_events_from_lace_external_source_projections : Specification
    {

        //private readonly EventReader _eventReader;
        //private readonly IProjectionContext _projectionContext;
        //private readonly IEventStoreConnection _connection;
        //private readonly ExternalSourceEventDetectorProjection _sourceRequestsProjection;
        //private const string StreamCategoryName = "ExternalSourceEvents";


        //public when_reading_events_from_lace_external_source_projections()
        //{
        //    _projectionContext = new ProjectionContext();
        //    _sourceRequestsProjection = new ExternalSourceEventDetectorProjection(_projectionContext);
        //    _connection = ConnectionFactory.Default();
        //    _eventReader = new EventReader(_connection);
        //}

        //public override void Observe()
        //{
        //    //_projectionContext.EnableProjection("$by_category");
        //    //_projectionContext.EnableProjection("$stream_by_category");

        //    //_sourceRequestsProjection.Ensure();

        //    //_eventReader.StartReading();
        //}

        //[Observation]
        //public void projection_for_lace_external_source_must_exist()
        //{
        //    var results = _connection.ReadStreamEventsBackward<ExternalSourceEventRead>(StreamCategoryName);
        //    results.Count().ShouldNotEqual(0);
        //}




        public override void Observe()
        {
            
        }
    }
} 
