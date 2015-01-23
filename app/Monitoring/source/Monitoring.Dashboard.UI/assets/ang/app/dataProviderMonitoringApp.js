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

    var imgPlus = "../assets/images/plus.gif";
    var imgMinus = "../assets/images/minus.gif";

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

        $scope.CollapseOrExpand = function(img) {
            var lastIndex = getLastIndex();
            if (lastIndex >= 0) {
                if (img.src === imgMinus) {
                    CollapseAllClicked(rawJsonId + lastIndex, canvasId);
                } else {
                    ExpandAllClicked(rawJsonId + lastIndex, canvasId);
                }
                SetExpandOrCollapseImage(img);
            }
        };
    });
});