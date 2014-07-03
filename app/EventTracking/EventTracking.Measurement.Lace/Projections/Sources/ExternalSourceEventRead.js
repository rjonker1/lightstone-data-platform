// <reference path="References\1Prelude.js" />
// <reference path="References\Projections.js" />

var externalSourceEventDetector = function externalSourceEventConstructor($eventServices) {


    var eventServices = !$eventServices ? { emit: emit } : $eventServices;

    
    //var createEvent = function (aggregateId, sourceId, message, timeStamp) {
       
    //    return {
    //        LastTimeStamp: timeStamp,
    //        //Total: reading,
    //        MessageCount: count,
    //        EventMessage: message


    //    };
    //};

    var createState = function (aggregateId, sourceId, message, timeStamp) {
        return {
            AggregateId: aggregateId,
            SourceId: sourceId,
            Message:message,
            TimeStamp: timeStamp
        };
    };

    var emitEvent = function(aggregateId, sourceId, message, timeStamp) {

        var streamName = 'ExternalSourceEvents'; // + event.streamId;
        //var newEvent = createEvent(event.body.EventDate, event.body.Message, state.Count);

        eventServices.emit(streamName, "ExternalSourceExecutionDetected", {
                AggregateId: aggregateId,
                SourceId: sourceId,
                Message: message,
                TimeStamp: timeStamp
            }
        );
    };
    
    var init = function() {
        return createState("", 0, "", null);
    };

    var processEvent = function (state, event) {
        
        var timeStamp = event.body.EventDate;
        var message = event.body.Message;
        var sourceId = event.body.SourceId;
        var aggregateId = event.body.AggregateId

        emitEvent(aggregateId, sourceId, message, timeStamp);
        return createState(aggregateId,sourceId,message,timeStamp);
    };

    return {
        init: init,
        processEvents: processEvent
    };
};

var detector = externalSourceEventDetector();

fromCategory('laceExternalSource')
    .foreachStream()
    .when({
        $init: detector.init,
        ExternalSourceEvent: detector.processEvents
    });