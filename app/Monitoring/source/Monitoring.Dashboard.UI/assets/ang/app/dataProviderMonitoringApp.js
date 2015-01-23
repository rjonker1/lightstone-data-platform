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

            //var sendRequest = function() {
            //    this.hub.invoke();
            //};
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

    //var setLastSelected = function(elementIndex, isCollapsed, img) {
    //    if (typeof(Storage) == "undefined") {
    //        console.log("Cannot store last selected item in the monitoring log. Storage not supported by browser");
    //    } else {
    //        localStorage.setItem("lastElementIndex", elementIndex);
    //        localStorage.setItem("isCollapsed", isCollapsed);

    //        if (img != null) {
    //            //var currentImageObject = new Image(img);
    //            localStorage.setItem("image", img);
    //        }

    //        console.log("Stored Last selected index = " + elementIndex + " And is collapsed = " + isCollapsed + " And img = " + img);
    //    }
    //};

    $scope.$parent.$on("dataProviderMonitoringInfo", function(e, result) {
        $scope.$apply(function() {
            $scope.dataProviderMonitoring = result;
        });

        $scope.Toggle = function(elementIndex, img) {
            Toggle(toggleId + elementIndex, img, rawJsonId + elementIndex, canvasId);
            setLastSelectedIndex(elementIndex);
        };

        $scope.CollapseAllClicked = function () {
            var lastIndex = getLastIndex();
            if (lastIndex >= 0) {
                CollapseAllClicked(rawJsonId + lastIndex, canvasId);
            }
        };

        $scope.ExpandAllClicked = function () {
            var lastIndex = getLastIndex();
            if (lastIndex >= 0) {
                ExpandAllClicked(rawJsonId + lastIndex, canvasId);
            }
        };
    });
});