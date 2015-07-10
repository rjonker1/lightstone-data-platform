"use strict";
var dataProviderMonitoringApp = angular.module("dataProviderMonitoringApp", ["ngRoute"])
    .service("dataProviderSignalRService", function($rootScope) {

        var init = function() {
            var hub = $.connection.dataProviderHub;

            hub.client.dataProviderMonitoringInfo = function(result) {
                $rootScope.$emit("dataProviderMonitoringInfo", result);
            };

            hub.client.dataProviderStatisticsInfo = function(result) {
                $rootScope.$emit("dataProviderStatisticsInfo", result);
            };

            $.connection.hub.start({ transport: 'longPolling' }).done(function () {
                hub.server.initRootUri();
            });

            hub.error = function(error) {
                console.warn("Error in Data Provider's Service: " + error);
            };

            hub.reconnected = function() {
                console.infolog("Data Provider's Service Reconnected");
            };

            hub.stateChanged = function(change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.info("Reconnecting to Data Provider SignalR Service");
                } else if (change.newState === $.signalR.connectionState.connected) {
                    console.info("Dataprovider Monitoring App is online");
                }
            };


        };

        var restart = function() {
            console.log("Restarting connection for service");
            var hub = $.connection.dataProviderHub;
            $.connection.hub.stop();
            $.connection.hub.start();
        };

        return { init: init, restart: restart };
    })
    .controller("DataProviderController", function($scope, dataProviderSignalRService, $rootScope) {

        $scope.dataProviderMonitoring = [];
        dataProviderSignalRService.init();

        var rawJsonId = "rawJson-";
        //var canvasId = "canvas-";
        var canvasId = "canvas-display";
        var toggleId = "toggle-";

        var setLastSelectedIndex = function(elementIndex) {
            if (typeof(Storage) == "undefined") {
                console.log("Cannot store last selected item in the monitoring log. Storage not supported by browser");
            } else {
                localStorage.setItem("lastElementIndex", elementIndex);
            }
        };

        var getLastIndex = function() {
            if (typeof(Storage) == "undefined") {
                console.log("Cannot store last selected item in the monitoring log. Storage not supported by browser");
                return -1;
            } else {
                return localStorage.lastElementIndex;
            }
        };

        var makeFormattedJsonVisible = function(formattedJsonId) {
            var ele = document.getElementById(formattedJsonId);
            if (ele.style.display === "none") {
                ele.style.display = "block";
            }
        };

        $scope.$parent.$on("dataProviderMonitoringInfo", function(e, result) {
            $scope.$apply(function() {
                $scope.dataProviderMonitoring = result;
            });

            $scope.Toggle = function(elementIndex, formattedJsonId) {
                Toggle(toggleId + elementIndex, rawJsonId + elementIndex, canvasId);
                setLastSelectedIndex(elementIndex);
                makeFormattedJsonVisible(formattedJsonId);
            };

            $scope.CollapseOrExpand = function(buttonId) {
                var element = document.getElementById(buttonId);
                var lastIndex = getLastIndex();
                if (lastIndex >= 0) {
                    if (element.value == "collapse") {
                        CollapseAllClicked(rawJsonId + lastIndex, canvasId);
                        element.value = "expand";
                    } else {
                        ExpandAllClicked(rawJsonId + lastIndex, canvasId);
                        element.value = "collapse";
                    }
                }
            };

            $scope.ReInitializeService = function() {
                //$scope.dataProviderMonitoring = [];
                //dataProviderSignalRService.init();
                dataProviderSignalRService.restart();
            };
        });
    }).controller("DataProviderStatisticsController", function ($scope, dataProviderSignalRService, $rootScope) {
        $scope.statistics = {};
        dataProviderSignalRService.init();

        $scope.$parent.$on("dataProviderStatisticsInfo", function(e, result) {
            $scope.$apply(function() {
                $scope.statistics = result[0];
            });

            $scope.ReInitializeService = function() {
                dataProviderSignalRService.restart();
            };
        });
    });