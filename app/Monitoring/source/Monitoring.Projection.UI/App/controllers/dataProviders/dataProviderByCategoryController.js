"use strict";

app.controller("dataProviderByCategoryController", function ($scope, $location, $filter, $window, $timeout, $routeParams, dataProviderService) {
   
    var vm = this;
    vm.dataProviders = [];
    vm.categoryId = ($routeParams.CategoryId) ? parseInt($routeParams.CategoryId) : 0;
    vm.totalRecords = 0;
    vm.pageSize = 10;
    vm.currentPage = 1;

    function getDataProviderByCategory() {
        dataProviderService.getMonitoringFromDataProvidersByCategory(vm.currentPage - 1, vm.pageSize, vm.categoryId)
            .then(function(data) {
                vm.totalRecords = data.totalRecords;
                vm.dataProviders = data.results;
            }, function(error) {
                $window.alert("An error occurred retrieving monitoring information: " + error.data.message);
            });
    }

    function init() {
        getDataProviderByCategory();
    }

    init();
});