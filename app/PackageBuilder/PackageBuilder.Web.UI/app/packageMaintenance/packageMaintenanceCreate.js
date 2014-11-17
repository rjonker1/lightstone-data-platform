(function () {
    'use strict';

    var controllerId = 'packageMaintenanceCreate';

    angular
        .module( 'app' )
        .controller(controllerId, packageMaintenanceCreate);

    packageMaintenanceCreate.$inject = ['$scope', '$location', '$timeout', '$parse', '$http', 'common', 'datacontext'];

    function packageMaintenanceCreate($scope, $location, $timeout, $parse, $http, common, datacontext) {

        $scope.title = 'Package Maintenance - Create';
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
        // Prevent $modelValue undefined error
        $scope.dataProvsPkg.Package = { 'mock': 'mock' };


        $scope.createPackage = function(packageData) {

            return datacontext.createPackage(packageData).then(function (response) {

                console.log(response);
                (response.status === 200) ? logSuccess('Package Created!') : logError('Error 404. Please check your connection settings');

            });

        }

        $scope.cancel = function () {

            $location.path('/packages');
        };

        $scope.filteredConstraint = '';

        $scope.filterIndustry = function (fields) {

            if (filterVal != 'All') {
                return fields.industry === filterVal;
            }

            return fields;
        };

       $scope.filterData = function(filter) {

           filterVal = filter.name;
       }

        $scope.total = function () {

            var rspCreate = angular.element(document.getElementById('rsp'));
            var valueTotal = 0;
            var items = null;

            try {

                items = $scope.dataProvsPkg.Package.DataProviders;
            } catch (e) {

                //console.log(e.message);
            }

            if (items != null) {

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
                                    return valueTotal;
                                }
                            }
                            
                            break;
                        
                        default:
                            break;
                    }

                }
            } 

            $scope.dataProvsPkg.Package.CostOfSale = valueTotal;

            if (valueTotal > rspCreate[0].value) {

                $scope.warning = true;
                $scope.rspCreateStyle = { 'color': 'red' };
            } else {

                $scope.warning = false;
                $scope.rspCreateStyle = { 'color': 'none' };
            }

            return valueTotal;
        };

        activate();
      
        function activate() {
            
            common.activateController([getDataProviders(), getStates(), getIndustries()], controllerId)
               .then(function () { log('Activated Package Maintenance View'); });
        }

        function getDataProviders() {

            return datacontext.getDataProviderSources().then(function (response) {

                if (response.status === 200) {

                    $scope.dataProvsPkg.Package.DataProviders = response.data;
                    $scope.dataProvsPkg.Package.state = 'Draft';
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
