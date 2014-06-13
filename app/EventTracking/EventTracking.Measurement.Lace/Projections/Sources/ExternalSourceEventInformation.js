// <reference path="References\1Prelude.js" />
// <reference path="References\Projections.js" />

var externalSourceInformationDetector = function externalSourceInformationConstructor($eventServices) {
    

    var eventServices = !$eventServices ? { emit: emit } : $eventServices;
    

    var aggregateId = "";
    var messageId = "";
    var source = "";
    var message = "";
    var eventDate = new Date();
    
    var init = function() {
        return {
            count: 0,
        };
    };

    var processEvent = function(state, event) {
        state.count += 1;
        aggregateId = event.body["AggregateId"];
        messageId = event.body["Id"];
        source = event.body["SourceId"];
        message = event.body["Message"];
        eventDate = event.body["EventDate"];

    };
    
    return {
        init: init,
        processExternalSourceEvents: processEvent
    };
};



var detector = externalSourceInformationDetector();

fromStream('externalSourceInformation')
    //.partitionBy(function(e) { return e.body["AggregateId"]; })
    .when({
        $init: detector.init,
        ExternalSourceEvent: detector.processExternalSourceEvents
    });
