//(function () {
//    var app = angular.module("monitoringApp", ["ngRoute"]);

//    app.config([
//        "$routeProvider", function ($routeProvider) {

//            var viewBase = "/app/views/";
//            $routeProvider
//                .when("/", {
//                    templateUrl: viewBase + "home.html",
//                    controller: "homeController"

//                })
//                .when("/dataProviders",
//                {
//                    templateUrl: viewBase + "dataProviders/dataProviders.html",
//                    controller: "dataProviderController",
//                    controllerAs: "vm"
//                })
//                .otherwise({ redirectTo: "/" });
//        }
//    ]);
//}());
//(function() {
var app = angular.module("monitoringApp", ["ngRoute"]);

app.config([
    "$routeProvider", function($routeProvider) {

        var viewBase = "/app/views/";
        $routeProvider
            .when("/", {
                templateUrl: viewBase + "home.html",
                controller: "homeController"

            })
            .when("/dataProviders",
            {
                templateUrl: viewBase + "dataProviders/dataProviders.html",
                controller: "dataProviderController",
                controllerAs: "vm"
            })
            .otherwise({ redirectTo: "/" });
    }
]).controller("mainController", function($scope) {
    //$scope.message = "Monitoring Main";
});

app.factory("dataProviderService", function ($http) {

    var serviceBase = "api/dataservice/", factory = {};

    function buildPagingUri(pageIndex, pageSize) {
        var uri = "?$top=" + pageSize + "&$skip=" + (pageIndex * pageSize);
        return uri;
    }

    function getPagedResource(baseResource, pageIndex, pageSize) {
        var resource = baseResource;
        resource += (arguments.length === 3) ? buildPagingUri(pageIndex, pageSize) : "";
        return $http.get(serviceBase + resource).then(function(response) {
            var data = response.data;
            return {
                totalRecords: parseInt(response.headers("X-InlineCount")),
                results: data
            }
        });
    }

    factory.getMonitoringFromDataProviders = function(pageIndex, pageSize) {
        return getPagedResource("dataProviders", pageIndex, pageSize);
    };

    return factory;
});

//}());

