// <reference path="References\1Prelude.js" />
// <reference path="References\Projections.js" />

var externalSourceInformationDetector = function externalSourceInformationConstructor($eventServices) {


    var eventServices = !$eventServices ? { emit: emit } : $eventServices;


    var isFirstTime = function (state) {
        return !state.lastTimeStamp;
    };

    var createEvent = function (timeStamp, message, count) {
        emit("created event with  " + message);

        return {
            LastTimeStamp: timeStamp,
            //Total: reading,
            MessageCount: count,
            EventMessage: message


        };
    };

    var createState = function (message, count, timestamp) {
        emit("creating state... with " + message + " and " + count + " and " + timestamp);
        return {
            //total: reading,
            Count: count,
            // Message: message,
            // TimeStamp: timestamp
        };
    };

    var emitEvent = function (event, state) {

        var streamName = 'ExternalSourceExecutionTime-' + event.streamId;
        var newEvent = createEvent(event.body.EventDate, event.body.Message, state.Count);
        emit("Created new event");
        eventServices.emit(streamName, "ExternalSourceExecutionTime", newEvent);
    };

    //var aggregateId = "";
    //var messageId = "";
    //var source = "";
    //var message = "";
    //var eventDate = new Date();

    var init = function () {
        emit("initialising...");
        return createState("", 0, null);
    };

    var processEvent = function (state, event) {
        emit("processing event...");
        var timeStamp = event.body.EventDate;
        var message = event.body.Message;
        emit(message);
        emit(timeStamp);
        //emitEvent(event, state);

        emitEvent(event, state);
        return createState(message, 1, timeStamp);
        //if (isFirstTime(state)) {
        //    emit("processing first time event...");
        //    return createState(message, state.count + 1, timeStamp);
        //} else {
        //    emit("else processing event...");
        //    emitEvent(event, state);
        //    return createState(message, 1, timeStamp);
        // }
        //state.count += 1;
        //aggregateId = event.body.AggregateId;
        //messageId = event.body.Id;
        //source = event.body.SourceId;
        //message = event.body.Message;
        //eventDate = event.body.EventDate;

    };

    return {
        init: init,
        processExternalSourceEvents: processEvent
    };
};



var detector = externalSourceInformationDetector();

fromCategory('laceExternalSource')
    .foreachStream()
    .when({
        $init: detector.init,
        ExternalSourceEvent: detector.processExternalSourceEvents
    });


//var externalSourceInformationDetector = function externalSourceInformationConstructor($eventServices) {
    

//    var eventServices = !$eventServices ? { emit: emit } : $eventServices;


//    var isFirstTime = function(state) {
//        return !state.lastTimeStamp;
//    };
    
//    var createEvent = function (timeStamp, message, count) {
//        return {
//            Timeslot: timeStamp,
//            //Total: reading,
//            Count: count,
//            Message: message
//        };
//    };

//    var createState = function (message, count, timestamp) {
//        emit("creating state...");
//        return {            
//            //total: reading,
//            count: count,
//            message: message,
//            lastTimeStamp: timestamp
//        };
//    };

//    var emitEvent = function(event, state) {

//        var streamName = 'ExternalSourceExecutionTime-' + event.streamId;
//        var newEvent = createEvent(state.lastTimeStamp, state.message, state.count);

//        eventServices.emit(streamName, "ExternalSourceExecutionTime", newEvent);
//    };

//    //var aggregateId = "";
//    //var messageId = "";
//    //var source = "";
//    //var message = "";
//    //var eventDate = new Date();
    
//    var init = function () {
//        emit("initialising...");
//        return createState("", 0, null);
//        //return {
//        //    count: 0,
//        //};
//    };

//    var processEvent = function (state, event) {
//        emit("processing event...");
//        var timeStamp = event.body["EventDate"];
//        var message = event.body["Message"];
        
//        if (isFirstTime(state)) {
//            emit("processing first time event...");
//            return createState(message, state.count + 1, timeStamp);
//        } else {
//            emit("else processing event...");
//            emitEvent(event, state);
//            return createState(message, 1, timeStamp);
//        }
//        //state.count += 1;
//        //aggregateId = event.body.AggregateId;
//        //messageId = event.body.Id;
//        //source = event.body.SourceId;
//        //message = event.body.Message;
//        //eventDate = event.body.EventDate;

//    };
    
//    return {
//        init: init,
//        processExternalSourceEvents: processEvent
//    };
//};



//var detector = externalSourceInformationDetector();

//fromCategory('laceExternalSource')
//    .foreachStream()
//    .when({
//        $init: detector.init,
//        ExternalSourceEvent: detector.processExternalSourceEvents
//    });
