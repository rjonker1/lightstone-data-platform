(function () {
    'use strict';

    var controllerId = 'packageMaintenanceEdit';

    angular
        .module('app')
        .controller(controllerId, packageMaintenanceCreate);

    packageMaintenanceCreate.$inject = ['$scope', '$routeParams', '$parse', '$http', 'common', 'datacontext'];

    function packageMaintenanceCreate($scope, $routeParams, $parse, $http, common, datacontext) {

        $scope.title = 'Package Maintenance - Edit';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.now = moment().format('MMMM Do YYYY, h:mm:ss a');

        $scope.dataProvsPkg = {};
        //Prevent $modelValue undefined error
        $scope.dataProvsPkg.Package = { 'mock' : 'mock' }


        $scope.editPackage = function (packageData) {

            return datacontext.editPackage($routeParams.id, packageData).then(function (response) {

                console.log(response);
                (response.status === 200) ? logSuccess('Package edited!') : logError('Error 404. Please check your connection settings');


            });

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

                //console.log(e.message);
            } 

            if ( items != null ) {

                for (var i = 0; i < items.length; i++) { // loop over it

                    var listItem = items[i]; // an object  

                    for (var x = 0; x < (listItem.dataFields).length; x++) {

                        if (listItem.dataFields[x].isSelected === true) {

                            //alert(listItem.name);
                            valueTotal += listItem.dataFields[x].price;
                        }
                    }

                }
            }

            if (cos != null) {

                $scope.dataProvsPkg.Package[0].costOfSale = valueTotal;
            }

            if (valueTotal < rspEdit[0].value) {

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

            common.activateController([getDataProvider($routeParams.id, $routeParams.version)], controllerId)
               .then(function () { log('Activated Package Maintenance View'); });
        }

        function getDataProvider(id, version) {

            return datacontext.getPackage(id, version).then(function (response) {

                console.log(response);

                if (response.status === 200) {

                    console.log(response.data.response);

                    $scope.dataProvsPkg.Package = response.data.response;


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

    }
})();
