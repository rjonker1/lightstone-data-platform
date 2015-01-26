﻿"use strict";
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

            hub.error = function(error) {
                console.warn("Error in Data Provider's SignalR Service: " + error);
            };

            hub.reconnected = function() {
                console.log("Data Provider's SignalR Service Reconnected");
            };

            hub.stateChanged = function(change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.log("Reconnecting to Data Provider SignalR Service");
                } else if (change.newState === $.signalR.connectionState.connected) {
                    console.log("Dataprovider Monitoring App is online");
                }
            };
        };

        return { init: init};
    })
    .controller("DataProviderController", function($scope, dataProviderSignalRService, $rootScope) {

    $scope.dataProviderMonitoring = [];
    dataProviderSignalRService.init();

    var rawJsonId = "rawJson-";
        //var canvasId = "canvas-";
    var canvasId = "canvas-display";
    var toggleId = "toggle-";

    var setLastSelectedIndex = function (elementIndex) {
        if (typeof(Storage) == "undefined") {
            console.log("Cannot store last selected item in the monitoring log. Storage not supported by browser");
        } else {
            localStorage.setItem("lastElementIndex", elementIndex);
        }
    };

    var getLastIndex = function() {
        if (typeof (Storage) == "undefined") {
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

        $scope.Toggle = function (elementIndex, formattedJsonId) {
            Toggle(toggleId + elementIndex, rawJsonId + elementIndex, canvasId);
            setLastSelectedIndex(elementIndex);
            makeFormattedJsonVisible(formattedJsonId);
        };

        //$scope.CollapseAllClicked = function (img) {
        //    var lastIndex = getLastIndex();
        //    if (lastIndex >= 0) {
        //        CollapseAllClicked(rawJsonId + lastIndex, canvasId);
        //        img.src = imgPlus;
        //    }
        //};

        //$scope.ExpandAllClicked = function (img) {
        //    var lastIndex = getLastIndex();
        //    if (lastIndex >= 0) {
        //        ExpandAllClicked(rawJsonId + lastIndex, canvasId);
        //        img.src = imgMinus;
        //    }
        //};

        $scope.CollapseOrExpand = function(button) {
            var lastIndex = getLastIndex();
            if (lastIndex >= 0) {
                if (button.value == "Collapse") {
                    CollapseAllClicked(rawJsonId + lastIndex, canvasId);
                    button.value = "Expand";
                } else {
                    ExpandAllClicked(rawJsonId + lastIndex, canvasId);
                    button.value = "Collapse";
                }
                //SetExpandOrCollapseImage(button);
                console.log(button.id);
            }
        };
    });
});