(function () {
    'use strict';

    var controllerId = 'packageMaintenanceCreate';

    angular
        .module('app')
        .controller(controllerId, packageMaintenanceCreate);

    packageMaintenanceCreate.$inject = ['$scope', '$parse', '$http', 'common', 'datacontext'];

    function packageMaintenanceCreate($scope, $parse, $http, common, datacontext) {

        $scope.title = 'Package Maintenance';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.now = moment().format('MMMM Do YYYY, h:mm:ss a');

        $scope.dataProvsPkg = {};
        //Prevent $modelValue undefined error
        $scope.dataProvsPkg.Package = { 'mock': 'mock' };


        $scope.createPackage = function(packageData) {

            return datacontext.createPackage(packageData).then(function (response) {

                console.log(response);
                (response.status === 200) ? logSuccess('Package Created!') : logError('Error 404. Please check your connection settings');

            });

        }

        $scope.dataProvs = {};
        $scope.dataProvs.provs = {};
        $scope.dataProvs.provs.prov = {};
        $scope.sum = 0;

        //Price aggregate
        $scope.updatePackageAPIModel = function(providers, providerName, fieldName) {


            for (var provs in providers) { //$scope.dataProvsPkg.Package

                var provider = providers[provs];

                for (var i = 0; i < provider.length; i++) {

                 
                   

                    for(var p in provider) {


                        if (provider.hasOwnProperty(p) && provider[p].name == providerName) {

                            var provFields = provider[p].dataFields; //Fields container for DataProvider

                            console.log(p);


                            for (var field in provFields) {

                               
                                if (provFields[field].name == fieldName) {

                                    if(provFields[field].isSelected == false) {

                                        provFields[field].isSelected = true;
                                    } else {

                                        provFields[field].isSelected = false;
                                    }
                                }

                            }

                            break;
                        }

                    } //End for-loop provider

                      

                }

            }
        }

        //Price aggregate update
        $scope.updateDataProvs = function (providerName, fieldName) {

            for (var providers in $scope.dataProvsPkg.Package){

                var provider = $scope.dataProvsPkg.Package[providers];

                for(var i = 0; i < provider.length; i++) {

                    for(var p in provider) {

                        if (provider.hasOwnProperty(p) && provider[p].name == providerName) {

                            console.log(provider[p].name);

                            var provFields = provider[p].dataFields; //Fields container for DataProvider

                            for(var field in provFields) {

                 
                                if(provFields[field].isSelected == true && provFields[field].name == fieldName) {

                                    // When we parse an AngularJS expression, we get back a function that
                                    // will evaluate the given expression in the context of a given $scope.
                                    //var dp = $parse('{'+field+':false}');
                                    var selectedFields = $scope.dataProvs.provs.prov;

                                    $scope.updatePackageAPIModel($scope.dataProvsPkg, fieldName);


                                    angular.forEach(selectedFields, function(value, key) {

                                        (key == fieldName) ? value = false : value = true;

                                        $scope.dataProvs.provs.prov[""+key] = value;
                    
                                    });

                                }

                            }
                    
                        }

                    } //End for-loop provider

                }

            }
        }


       
        $scope.findProvFieldByName = function (providers, fieldName) {


            for (var provs in $scope.dataProvsPkg.Package){

                var provider = $scope.dataProvsPkg.Package[provs];

                for(var i = 0; i < provider.length; i++) {

                    for(var p in provider) {

                        if(provider.hasOwnProperty(p)) {

                            var provFields = provider[p].dataFields; //Fields container for DataProvider

                            //$scope.test = provFields;

                            for(var field in provFields) {

                                if(provFields[field].name == fieldName)
                                    return provFields[field];

                            }
                        }

                    } //End for-loop provider

                }

            }

            return null;
        }


        
        $scope.$watch('dataProvs', function (newValue, oldValue) {


            var provider = newValue.provs.prov;
            var sum = 0;
            for ( var prov in provider ){

                var dataProvList = $scope.dataProvsPkg;
           
                if ( provider[prov] ){
               
                    var provPrice = $scope.findProvFieldByName(dataProvList, prov);
                    if ( provPrice !== null ){

                        sum += parseFloat(provPrice.price, 10,2);
                    }
                }
            }
            $scope.sum = sum;

        }, true);

        $scope.toggle = function(scope) {
            scope.toggle();
        };

        $scope.moveLastToTheBegginig = function () {
            var a = $scope.data.pop();
            $scope.data.splice(0,0, a);
        };

        $scope.collapseAll = function() {
            $scope.$broadcast('collapseAll');
        };

        $scope.expandAll = function() {
            $scope.$broadcast('expandAll');
        }


        activate();

        function activate() {
            
            common.activateController([getDataProviders()], controllerId)
               .then(function () { log('Activated Package Maintenance View'); });
        }

        function getDataProviders() {

            return datacontext.getDataProviderSources().then(function (response) {

                console.log(response);

                if (response.status === 200) {



                    $scope.dataProvsPkg.Package.DataProviders = response.data;


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
