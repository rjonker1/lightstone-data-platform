var stats = {
    type: "GROUP",
name: "Global Information",
path: "",
pathFormatted: "missing-name-b06d1db11321396efb70c5c483b11923",
stats: {
    "name": "Global Information",
    "numberOfRequests": {
        "total": "10",
        "ok": "10",
        "ko": "0"
    },
    "minResponseTime": {
        "total": "6832",
        "ok": "6832",
        "ko": "-"
    },
    "maxResponseTime": {
        "total": "11669",
        "ok": "11669",
        "ko": "-"
    },
    "meanResponseTime": {
        "total": "8477",
        "ok": "8477",
        "ko": "-"
    },
    "standardDeviation": {
        "total": "1301",
        "ok": "1301",
        "ko": "-"
    },
    "percentiles1": {
        "total": "10805",
        "ok": "10805",
        "ko": "-"
    },
    "percentiles2": {
        "total": "11496",
        "ok": "11496",
        "ko": "-"
    },
    "group1": {
        "name": "t < 800 ms",
        "count": 0,
        "percentage": 0
    },
    "group2": {
        "name": "800 ms < t < 1200 ms",
        "count": 0,
        "percentage": 0
    },
    "group3": {
        "name": "t > 1200 ms",
        "count": 10,
        "percentage": 100
    },
    "group4": {
        "name": "failed",
        "count": 0,
        "percentage": 0
    },
    "meanNumberOfRequestsPerSecond": {
        "total": "0.16",
        "ok": "0.16",
        "ko": "-"
    }
},
contents: {
"string-body-f271fd5cbfb8bab5dd13edd8c7006f49": {
        type: "REQUEST",
        name: "String body",
path: "String body",
pathFormatted: "string-body-f271fd5cbfb8bab5dd13edd8c7006f49",
stats: {
    "name": "String body",
    "numberOfRequests": {
        "total": "10",
        "ok": "10",
        "ko": "0"
    },
    "minResponseTime": {
        "total": "6832",
        "ok": "6832",
        "ko": "-"
    },
    "maxResponseTime": {
        "total": "11669",
        "ok": "11669",
        "ko": "-"
    },
    "meanResponseTime": {
        "total": "8477",
        "ok": "8477",
        "ko": "-"
    },
    "standardDeviation": {
        "total": "1301",
        "ok": "1301",
        "ko": "-"
    },
    "percentiles1": {
        "total": "10805",
        "ok": "10805",
        "ko": "-"
    },
    "percentiles2": {
        "total": "11496",
        "ok": "11496",
        "ko": "-"
    },
    "group1": {
        "name": "t < 800 ms",
        "count": 0,
        "percentage": 0
    },
    "group2": {
        "name": "800 ms < t < 1200 ms",
        "count": 0,
        "percentage": 0
    },
    "group3": {
        "name": "t > 1200 ms",
        "count": 10,
        "percentage": 100
    },
    "group4": {
        "name": "failed",
        "count": 0,
        "percentage": 0
    },
    "meanNumberOfRequestsPerSecond": {
        "total": "0.16",
        "ok": "0.16",
        "ko": "-"
    }
}
    }
}

}

function fillStats(stat){
    $("#numberOfRequests").append(stat.numberOfRequests.total);
    $("#numberOfRequestsOK").append(stat.numberOfRequests.ok);
    $("#numberOfRequestsKO").append(stat.numberOfRequests.ko);

    $("#minResponseTime").append(stat.minResponseTime.total);
    $("#minResponseTimeOK").append(stat.minResponseTime.ok);
    $("#minResponseTimeKO").append(stat.minResponseTime.ko);

    $("#maxResponseTime").append(stat.maxResponseTime.total);
    $("#maxResponseTimeOK").append(stat.maxResponseTime.ok);
    $("#maxResponseTimeKO").append(stat.maxResponseTime.ko);

    $("#meanResponseTime").append(stat.meanResponseTime.total);
    $("#meanResponseTimeOK").append(stat.meanResponseTime.ok);
    $("#meanResponseTimeKO").append(stat.meanResponseTime.ko);

    $("#standardDeviation").append(stat.standardDeviation.total);
    $("#standardDeviationOK").append(stat.standardDeviation.ok);
    $("#standardDeviationKO").append(stat.standardDeviation.ko);

    $("#percentiles1").append(stat.percentiles1.total);
    $("#percentiles1OK").append(stat.percentiles1.ok);
    $("#percentiles1KO").append(stat.percentiles1.ko);

    $("#percentiles2").append(stat.percentiles2.total);
    $("#percentiles2OK").append(stat.percentiles2.ok);
    $("#percentiles2KO").append(stat.percentiles2.ko);

    $("#meanNumberOfRequestsPerSecond").append(stat.meanNumberOfRequestsPerSecond.total);
    $("#meanNumberOfRequestsPerSecondOK").append(stat.meanNumberOfRequestsPerSecond.ok);
    $("#meanNumberOfRequestsPerSecondKO").append(stat.meanNumberOfRequestsPerSecond.ko);
}
