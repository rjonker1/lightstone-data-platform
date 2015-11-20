var stats = {
    type: "GROUP",
name: "Global Information",
path: "",
pathFormatted: "missing-name-b06d1db11321396efb70c5c483b11923",
stats: {
    "name": "Global Information",
    "numberOfRequests": {
        "total": "40",
        "ok": "16",
        "ko": "24"
    },
    "minResponseTime": {
        "total": "8104",
        "ok": "8104",
        "ko": "31518"
    },
    "maxResponseTime": {
        "total": "45215",
        "ok": "45215",
        "ko": "39034"
    },
    "meanResponseTime": {
        "total": "30491",
        "ok": "23699",
        "ko": "35018"
    },
    "standardDeviation": {
        "total": "10529",
        "ok": "13888",
        "ko": "2218"
    },
    "percentiles1": {
        "total": "44050",
        "ok": "44675",
        "ko": "38467"
    },
    "percentiles2": {
        "total": "44934",
        "ok": "45107",
        "ko": "38905"
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
        "count": 16,
        "percentage": 40
    },
    "group4": {
        "name": "failed",
        "count": 24,
        "percentage": 60
    },
    "meanNumberOfRequestsPerSecond": {
        "total": "0.40",
        "ok": "0.16",
        "ko": "0.24"
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
        "total": "40",
        "ok": "16",
        "ko": "24"
    },
    "minResponseTime": {
        "total": "8104",
        "ok": "8104",
        "ko": "31518"
    },
    "maxResponseTime": {
        "total": "45215",
        "ok": "45215",
        "ko": "39034"
    },
    "meanResponseTime": {
        "total": "30491",
        "ok": "23699",
        "ko": "35018"
    },
    "standardDeviation": {
        "total": "10529",
        "ok": "13888",
        "ko": "2218"
    },
    "percentiles1": {
        "total": "44050",
        "ok": "44675",
        "ko": "38467"
    },
    "percentiles2": {
        "total": "44934",
        "ok": "45107",
        "ko": "38905"
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
        "count": 16,
        "percentage": 40
    },
    "group4": {
        "name": "failed",
        "count": 24,
        "percentage": 60
    },
    "meanNumberOfRequestsPerSecond": {
        "total": "0.40",
        "ok": "0.16",
        "ko": "0.24"
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
