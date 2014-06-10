// <reference path="References\1Prelude.js" />
// <reference path="References\Projections.js" />

var requestsSentToSourcesDetector = function requestsSentToSourcesConstructor($eventServices) {

    var eventServices = !$eventServices ? { emit: emit } : $eventServices;

    var init = function() {
        return {
          RequestsSent: [],   
        };
    };

    var process = function(state, messageId, aggregateId, source, eventDate) {
        var results = state.RequestsSent;
        return state;
    };

    var processEvent = function(state, event) {
        var messageId = event.body.Id;
        var aggregateId = event.body.AggregateId;
        var source = event.body.source;
        var eventDate = event.body.EventDate;

        return process(state, messageId, aggregateId, source, eventDate);
    };

    return {        
        init: init,
        processRequestsSent : processEvent
    };

};


var detector = requestsSentToSourcesDetector();


fromCategory('ExternalSourceRequestSentEvent')
    .foreachStream()
    .when({
        $init: detector.init,
        RequestsSent: detector.processRequestsSent
    });