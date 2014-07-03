// <reference path="References\1Prelude.js" />
// <reference path="References\Projections.js" />

var externalSourceEventDetector = function externalSourceEventConstructor($eventServices) {


    var eventServices = !$eventServices ? { emit: emit } : $eventServices;

    var createState = function (aggregateId, sourceId, message, timeStamp, order) {
        return {
            AggregateId: aggregateId,
            SourceId: sourceId,
            Message: message,
            TimeStamp: timeStamp,
            Order: order,
        };
    };

    var emitEvent = function(state, aggregateId, sourceId, message, timeStamp, order) {

        //var streamName = 'ExternalSourceEvents'; // + event.streamId;
        //var newEvent = createEvent(event.body.EventDate, event.body.Message, state.Count);

        eventServices.emit('ExternalSourceExecutionEvents', 'ExternalSourceExecutionDetected', {
                AggregateId: aggregateId,
                SourceId: sourceId,
                Message: message,
                TimeStamp: timeStamp,
                Order: order,
            }
        );
    };

    var init = function() {
        return createState("", 0, "", null,0);
    };

    var processEvent = function(state, event) {

        var timeStamp = event.body.EventDate;
        var message = event.body.Message;
        var sourceId = event.body.SourceId;
        var aggregateId = event.body.AggregateId;
        var order = event.body.Order;

        emitEvent(state, aggregateId, sourceId, message, timeStamp,order);
        return createState(aggregateId, sourceId, message, timeStamp,order);
    };

    return {
        init: init,
        processEvents: processEvent
    };
};

var detector = externalSourceEventDetector();

fromCategory('laceExecutingExternalSource')
    .foreachStream()
    .when({
        $init: detector.init,
        ExternalSourceExecutedEvent: detector.processEvents
    });