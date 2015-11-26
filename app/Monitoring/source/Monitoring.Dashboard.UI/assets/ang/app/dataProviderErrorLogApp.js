"use strict";
var dataProviderErrorLogApp = angular.module("dataProviderErrorLogApp", ["ngRoute"])
    .service("dataProviderErrorLogService", function($rootScope) {

        var init = function() {
            var hub = $.connection.dataProviderErrorLogHub;

            hub.client.dataProviderErrors = function (result) {
                $rootScope.$emit("dataProviderErrors", result);
            };

            $.connection.hub.start({ transport: "longPolling" }).done(function() {
                hub.server.initRootUri();
            });

            hub.error = function(error) {
                console.warn("Error in Data Provider's Error Log Service: " + error);
            };

            hub.reconnected = function() {
                console.infolog("Data Provider's Error Log Service Reconnected");
            };

            hub.stateChanged = function(change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.info("Reconnecting to Data Provider Error Log Service");
                } else if (change.newState === $.signalR.connectionState.connected) {
                    console.info("Dataprovider Error Log App is online");
                }
            };
        };

        var restart = function() {
            console.log("Restarting connection for service");
            var hub = $.connection.dataProviderErrorLogHub;
            $.connection.hub.stop();
            $.connection.hub.start();
        };

        return { init: init, restart: restart };
    })
    .controller("dataProviderErrorLogController", function ($scope, dataProviderErrorLogService, $rootScope) {

        $scope.dataProviderErrors = [];
        dataProviderErrorLogService.init();

        var rawJsonId = "rawJson-";
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

        $scope.$parent.$on("dataProviderErrors", function (e, result) {
            $scope.$apply(function () { $scope.dataProviderErrors = result; });

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

            $scope.reInitializeService = function () {
                dataProviderErrorLogService.restart();
            };
        });
    });