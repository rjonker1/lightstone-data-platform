var app = angular.module("monitoringApp", ["ngRoute"])
    .config([
        "$routeProvider", function ($routeProvider) {
            $routeProvider
                .when("/", {
                    templateUrl: "views/home.html",
                    controller: "homeController"
                })
                .when("/dataProviders",
                {
                    templateUrl: "views/dataProviders.html",
                    controller: "dataProviderController"
                })
                .otherwise({ redirectTo: "/" });
        }
    ]).controller("mainController", function($scope) {
    //$scope.message = "Monitoring Main";
});