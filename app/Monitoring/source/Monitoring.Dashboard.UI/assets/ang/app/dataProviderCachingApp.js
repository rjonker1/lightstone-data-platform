"use strict";
var dataProviderCachingApp = angular.module("dataProviderCachingApp", ["ngRoute"])
    .controller("CachingController", ["$scope", "$http", function ($scope, $http) {
        $scope.refresh = function () {
            $http.post("/dataProviders/caching/refresh").
                success(function(data) {
                });
        };
        
        $scope.clear = function () {
            $http.post("/dataProviders/caching/clear").
                success(function (data) {
                });
        };
        
        $scope.restart = function () {
            $http.post("/dataProviders/caching/restart").
                success(function (data) {
                });
        };
    }]);