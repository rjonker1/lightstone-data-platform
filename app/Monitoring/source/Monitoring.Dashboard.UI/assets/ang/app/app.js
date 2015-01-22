"use strict";
var dataProviderMonitoringApp = angular.module("dataProviderMonitoringApp", ["ngRoute"])
    .service("dataProviderSignalRService", function($rootScope) {

        var init = function() {
            var hub = $.connection.dataProviderHub;

            hub.client.dataProviderMonitoringInfo = function(result) {
                $rootScope.$emit("dataProviderMonitoringInfo", result);
            }
            $.connection.hub.start().done(function() {
                hub.server.initRootUri();
            });
        };

        return { init: init };
    })
    .controller("DataProviderController", function($scope, dataProviderSignalRService, $rootScope) {

    $scope.dataProviderMonitoring = [];
    dataProviderSignalRService.init();

    var rawJsonId = "rawJson-";
    var canvasId = "canvas-";
    var toggleId = "toggle-";

    $scope.$parent.$on("dataProviderMonitoringInfo", function(e, result) {
        $scope.$apply(function() {
            $scope.dataProviderMonitoring = result;
            //console.log($scope.dataProviderMonitoring);
        });

        $scope.Toggle = function(elementIndex, img) {
            Toggle(toggleId + elementIndex, img, rawJsonId + elementIndex, canvasId + elementIndex);
        };

        $scope.CollapseAllClicked = function(elementIndex) {
            CollapseAllClicked(rawJsonId + elementIndex, canvasId + elementIndex);
        };

        $scope.ExpandAllClicked = function(elementIndex) {
            ExpandAllClicked(rawJsonId + elementIndex, canvasId + elementIndex);
        };
    });
});