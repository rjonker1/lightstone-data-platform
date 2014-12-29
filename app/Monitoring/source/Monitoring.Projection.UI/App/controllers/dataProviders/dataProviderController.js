//(function() {
//    alert("here");
//    //var dataProviderController = function ($scope) {

//    //    var vm = this;
//    //    vm.message = "Monitoring the Data Providers";
//    //    $scope.message = vm.message;
//    //};
//    var injectParams = [
//        "$location", "$filter", "$window",
//        "$timeout", "dataProviderService"];

//    var dataProviderController = function($location, $filter, $window,
//        $timeout, dataProviderService) {
        
//        var vm = this;
//        vm.dataProviders = [];

//        vm.totalRecords = 0;
//        vm.pageSize = 10;
//        vm.currentPage = 1;


//        function getDataProviderSummary() {
//            alert("Get Data Providers");
//            dataProviderService.getMonitoringFromDataProviders(vm.currentPage - 1, vm.pageSize)
//                .then(function(data) {
//                    vm.totalRecords = data.totalRecords;
//                    vm.dataProviders = data.results;

//                    $timeout(function() {
//                        //vm.cardAnimationClass = ""; //Turn off animation since it won't keep up with filtering
//                    }, 1000);

//                }, function(error) {
//                    $window.alert("An error occurred retrieving monitoring information: " + error.data.message);
//                });
//        }

//        vm.pageChanged = function(page) {
//            vm.currentPage = page;
//            getDataProviderSummary();
//        };

//        function init() {
//            alert("init");
//            getDataProviderSummary();
//        }

//        init();
//    };

    

//    alert("here again");
//    dataProviderController.$inject = injectParams;
//    angular.module("monitoringApp").controller("dataProviderController", dataProviderController);
//}());

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

            //$timeout(function() {
            //    //vm.cardAnimationClass = ""; //Turn off animation since it won't keep up with filtering
            //}, 1000);

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