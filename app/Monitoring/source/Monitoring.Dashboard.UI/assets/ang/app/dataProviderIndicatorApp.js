﻿"use strict";
var dataProviderIndicatorApp = angular.module("dataProviderIndicatorApp", ["ngRoute"])
    .service("dataProviderIndicatorAppService", function ($rootScope) {
        var init = function() {
            var hub = $.connection.dataProviderIndicatorHub;
            hub.client.dataProviderIndicators = function (result) {
                $rootScope.$emit("dataProviderIndicators", result);
            };
            $.connection.hub.start({ transport: "longPolling" }).done(function () {
                hub.server.initRootUri();
            });
            hub.error = function (error) {
                console.warn("Error in Data Provider's Indicator Service: " + error);
            };
            hub.reconnected = function () {
                console.infolog("Data Provider's Indicator Service Reconnected");
            };
            hub.stateChanged = function (change) {
                if (change.newState === $.signalR.connectionState.reconnecting) {
                    console.info("Reconnecting to Data Provider Indicator Service");
                } else if (change.newState === $.signalR.connectionState.connected) {
                    console.info("Dataprovider Indicator App is online");
                }
            };
        };

        var restart = function () {
            console.log("Restarting connection for Indicator's service");
            var hub = $.connection.dataProviderIndicatorHub;
            $.connection.hub.stop();
            $.connection.hub.start();
        };

        return { init: init, restart: restart };

    })
    .controller("dataProviderIndicatorController", function ($scope, dataProviderIndicatorAppService, $rootScope, $location, $window) {
        $scope.dataProviderIndicators = {};
        $scope.dataProviderIndicators.requestLevel = {};
        $scope.dataProviderIndicators.requestPerDataProvider = [];
        $scope.dataProviderIndicators.requestTimePerDataProvider = [];
        $scope.dataProviderIndicators.requestFieldCounts = [];
        dataProviderIndicatorAppService.init();

        $scope.$parent.$on("dataProviderIndicators", function(e, result) {
            $scope.$apply(function() {
                $scope.dataProviderIndicators = result;
                $scope.dataProviderIndicators.requestLevel = result.RequestLevel;
                $scope.dataProviderIndicators.requestPerDataProvider = result.RequestPerDataProvider;
                $scope.dataProviderIndicators.requestTimePerDataProvider = result.RequestTimePerDataProvider;
                $scope.dataProviderIndicators.requestFieldCounts = result.RequestFieldCounts;
            });

            $scope.ReInitializeService = function() {
                dataProviderIndicatorAppService.restart();
            };

            $scope.viewAllRequests = function () {
                $window.location.href = "/dataProviders/log";
            }

            $scope.viewErrors = function () {
                $window.location.href = "/dataProviders/log/errors";
            }
        });

    });