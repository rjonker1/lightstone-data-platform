"use strict";
var dataProviderQueryMonitoringApp = angular.module("dataProviderQueryMonitoringApp", ["ngRoute"])
    .controller("DataProviderQueryController", ["$scope", "$http", function ($scope, $http) {
        $scope.QueryResults = {};
        $scope.QueryResults.Response = [];
        $scope.QueryResults.Pages = [];
        $scope.Query = function (argumentElementId) {
            var argument = document.getElementById(argumentElementId).value;
            $scope.status = 404;
            $http.post("/dataProviders/log/search/" + argument + "/page/0").
               success(function (data) {
                   $scope.QueryResults.Response = data.response;
                   $scope.QueryResults.Pages = data.pages;
                   console.log($scope.QueryResults.Pages);
               }).error(function (data, status) {
                   $scope.status = status;
               });
        };

        $scope.QueryWithPage = function (argumentElementId, page) {
            console.log("page number: " + page);
            var argument = document.getElementById(argumentElementId).value;
            $scope.status = 404;
            $http.post("/dataProviders/log/search/" + argument + "/page/" + page).
               success(function (data) {
                   $scope.QueryResults.Response = data.response;
                   $scope.QueryResults.Pages = data.pages;
                   console.log($scope.QueryResults.Pages);
               }).error(function (data, status) {
                   $scope.status = status;
               });
        };

        var rawJsonId = "rawJson-";
        var canvasId = "canvas-display";
        var toggleId = "toggle-";

        var setLastSelectedIndex = function (elementIndex) {
            if (typeof (Storage) == "undefined") {
                console.log("Cannot store last selected item in the monitoring log. Storage not supported by browser");
            } else {
                localStorage.setItem("lastElementIndex", elementIndex);
            }
        };

        var getLastIndex = function () {
            if (typeof (Storage) == "undefined") {
                console.log("Cannot store last selected item in the monitoring log. Storage not supported by browser");
                return -1;
            } else {
                return localStorage.lastElementIndex;
            }
        };

        var makeFormattedJsonVisible = function (formattedJsonId) {
            var ele = document.getElementById(formattedJsonId);
            if (ele.style.display === "none") {
                ele.style.display = "block";
            }
        };

        $scope.Toggle = function (elementIndex, formattedJsonId) {
            Toggle(toggleId + elementIndex, rawJsonId + elementIndex, canvasId);
            setLastSelectedIndex(elementIndex);
            makeFormattedJsonVisible(formattedJsonId);
        };

        $scope.CollapseOrExpand = function (buttonId) {
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

    }]);