(function () {
    'use strict';

    var controllerId = 'packageView';

    angular
        .module('app')
        .controller(controllerId, packageView);

    packageView.$inject = ['$scope', '$location', '$routeParams', '$parse', '$http', 'common', 'datacontext'];

    function packageView($scope, $location, $routeParams, $parse, $http, common, datacontext) {

        $scope.title = 'Package Maintenance - View';
        var filterVal = 'All';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.users = [

        { name: 'Al' },
        { name: 'user2' },
        { name: 'user3' }
        ];

        $scope.format = 'MMMM Do YYYY, h:mm:ss a';

        $scope.dataProvsPkg = {};
        //Prevent $modelValue undefined error
        $scope.dataProvsPkg.Package = { 'mock' : 'mock' }

        $scope.cancel = function () {

            $location.path('/packages');
        };

        $scope.filterIndustry = function (fields) {

            if (filterVal != 'All') {
                return fields.industry === filterVal;
            }

            return fields;
        };

        $scope.filterData = function (filter) {

            filterVal = filter.name;
        }

        $scope.total = function () {

            var rspEdit = angular.element(document.getElementById('rsp'));
            var valueTotal = 0;
            var items = null;
            var cos = null;

            try {
                
                items = $scope.dataProvsPkg.Package[0].dataProviders;
                cos = $scope.dataProvsPkg.Package[0].costOfSale;
            } catch (e) {

            } 

            if ( items != null ) {

                for (var i = 0; i < items.length; i++) { 

                    var listItem = items[i];

                    switch (listItem.fieldLevelCostPriceOverride) {
                        case true:

                            for (var x = 0; x < (listItem.dataFields).length; x++) {

                                if (listItem.dataFields[x].isSelected === true) {

                                    valueTotal += listItem.dataFields[x].price;
                                }
                            }

                            break;
                        case false:

                            for (var x = 0; x < (listItem.dataFields).length; x++) {

                                if (listItem.dataFields[x].isSelected === true) {

                                    valueTotal += listItem.costOfSale;
                                    break;
                                }
                            }

                            break;
                    }

                }
            }

            if (cos != null) {

                $scope.dataProvsPkg.Package[0].costOfSale = valueTotal;
            }

            if (valueTotal > rspEdit[0].value) {

                $scope.warning = true;
                $scope.rspEditStyle = { 'color': 'red' };
            } else {

                $scope.warning = false;
                $scope.rspEditStyle = { 'color': 'none' };
            }

            return valueTotal;
        };


        activate();

        function activate() {

            common.activateController([getPackage($routeParams.id, $routeParams.version), getStates(), getIndustries()], controllerId)
               .then(function () { log('Activated Package Maintenance View'); });
        }

        function getPackage(id, version) {

            return datacontext.getPackage(id, version).then(function (response) {

                if (response.status === 200) {

                    $scope.dataProvsPkg.Package = response.data.response;
                    //Manipulate current state of Pakage at load to reflect alias of enum from API

                    //State comparison
                    for (var i = 0; i < $scope.states.length; i++) {
                        if ($scope.dataProvsPkg.Package[0].state.id == $scope.states[i].id) {
                            $scope.dataProvsPkg.Package[0].state = $scope.states[i];
                        }
                    }

                    logSuccess('Data Providers loaded!');

                }

                if (response.status === 404) {

                    //Load MOCK data
                    $http({
                        method: 'GET',
                        url: '/app/packageMaintenance/DataProviders.json'
                    }).success(function (data, status, headers, config) {

                        $scope.dataProvsPkg = data;

                    }).error(function (data, status, headers, config) {

                    });

                    logError('Error 404. Please check your connection settings');
                }

            });
        }

        function getStates() {

            return datacontext.getStates().then(function (response) {

                $scope.states = response;
            });
        }

        function getIndustries() {

            return datacontext.getIndustries().then(function (response) {

                $scope.industries = response;
                $scope.filteredConstraint = $scope.industries[0];
            });
        }

    }
})();
