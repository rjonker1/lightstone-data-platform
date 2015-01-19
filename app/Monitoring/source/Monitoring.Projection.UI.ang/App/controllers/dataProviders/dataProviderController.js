"use strict";

app.controller("dataProviderController", function($scope, $location, $filter, $window,
    $timeout, dataProviderService) {
    $scope.message = "Data Providers";
    var vm = this;
    vm.dataProviders = [];

    vm.totalRecords = 0;
    vm.pageSize = 10;
    vm.currentPage = 1;


    function getDataProviderSummary() {
        dataProviderService.getMonitoringFromDataProviders(vm.currentPage - 1, vm.pageSize)
            .then(function(data) {
                vm.totalRecords = data.totalRecords;
            vm.dataProviders = data.results;

        }, function(error) {
                $window.alert("An error occurred retrieving monitoring information: " + error.data.message);
            });
    }

    vm.pageChanged = function(page) {
        vm.currentPage = page;
        getDataProviderSummary();
    };

    function init() {
        getDataProviderSummary();
    }

    init();

});