"use strict";
var apiRequestMetadataApp = angular.module("apiRequestMetadataApp", ["ngRoute"])
    .service("apiRequestSignalRService", function($rootScope) {
        var init = function() {
            var hub = $.connection.apiRequestHub;
            hub.client.apiRequestMetadataInfo = function(result) {
                $rootScope.$emit("apiRequestMetadataInfo", result);
            };
            hub.client.apiRequestMetadataInfo = function(result) {
                $rootScope.$emit("apiRequestMetadataInfo", result);
            };
            $.connection.hub.start({ transport: 'longPolling' }).done(function() {
                hub.server.initRootUri();
            });
            hub.error = function(error) {
                console.warn("Error in Api Request's Service: " + error);
            };
            hub.reconnected = function() {
                console.infolog("Api Request Service Reconnected");
            };
            hub.stateChanged = function(change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.info("Reconnecting to Api Request Service");
                } else if (change.newState === $.signalR.connectionState.connected) {
                    console.info("Dataprovider Api Request Monitoring App is online");
                }
            };
        };

        var restart = function() {
            console.log("Restarting connection for service");
            var hub = $.connection.apiRequestHub;
            $.connection.hub.stop();
            $.connection.hub.start();
        };

        return { init: init, restart: restart };

    }).controller("ApiRequestMetatdataController", function($scope, apiRequestSignalRService, $rootScope) {
        $scope.apiRequests = [];
        apiRequestSignalRService.init();
        $scope.$parent.$on("apiRequestMetadataInfo", function(e, result) {
            $scope.$apply(function() {
                $scope.apiRequests = result;
            });
        });
    });