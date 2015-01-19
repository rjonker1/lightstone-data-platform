"use strict";

app.controller("dataProviderByAggregateController", function ($scope, $location, $filter, $window, $timeout, $routeParams, dataProviderService) {
   
    var vm = this;
    vm.dataProviders = [];
    vm.aggregateId = ($routeParams.AggregateId) ? $routeParams.AggregateId : "";
    vm.totalRecords = 0;
    vm.pageSize = 10;
    vm.currentPage = 1;

    function getDataProviderByAggregate() {
        dataProviderService.getMonitoringFromDataProvidersByAggregate(vm.currentPage - 1, vm.pageSize, vm.aggregateId)
            .then(function(data) {
                vm.totalRecords = data.totalRecords;
                vm.dataProviders = data.results;
            }, function(error) {
                $window.alert("An error occurred retrieving monitoring information: " + error.data.message);
            });
    }

    function init() {
        getDataProviderByAggregate();
    }

    init();
});