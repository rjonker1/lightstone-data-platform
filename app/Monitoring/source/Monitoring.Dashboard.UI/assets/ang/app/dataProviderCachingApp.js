"use strict";
var dataProviderCachingApp = angular.module("dataProviderCachingApp", ["ngRoute"])
    .controller("CachingController", ['$scope', '$http', function ($scope, $http) {
        $scope.refresh = function () {
            $http.post('http://dev.monitoring.web.lightstone.co.za/dataProviders/caching/refresh').
                success(function(data) {
                });
        };
        
        $scope.clear = function () {
            $http.post('http://dev.monitoring.web.lightstone.co.za/dataProviders/caching/clear').
                success(function (data) {
                });
        };
        
        $scope.restart = function () {
            $http.post('http://dev.monitoring.web.lightstone.co.za/dataProviders/caching/restart').
                success(function (data) {
                });
        };
    }]);