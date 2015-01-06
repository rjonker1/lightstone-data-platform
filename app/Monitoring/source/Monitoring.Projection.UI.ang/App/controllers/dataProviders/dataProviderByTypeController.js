"use strict";
app.controller("dataProviderByTypeController", function($scope, $location, $filter, $window, $timeout, $routeParams, dataProviderService) {
    var vm = this;
    vm.dataProviders = [];
    vm.dataProviderId = ($routeParams.DataProviderId) ? parseInt($routeParams.DataProviderId) : 0;
    vm.totalRecords = 0;
    vm.pageSize = 10;
    vm.currentPage = 1;

    function getDataProviderByType() {
        dataProviderService.getMonitoringFromDataProvidersByType(vm.currentPage - 1, vm.pageSize, vm.dataProviderId)
            .then(function(data) {
                vm.totalRecords = data.totalRecords;
                vm.dataProviders = data.results;
            }, function(error) {
                $window.alert("An error occurred  retrieving monitoring information: " + error.data.message);
            });
    }

    function init() {
        getDataProviderByType();
    }

    init();
});