(function () {
    'use strict';

    var controllerId = 'dataProviderDetail';

    angular
        .module( 'app' )
        .controller( controllerId, dataProviderDetail );

    dataProviderDetail.$inject = ['$scope','$location', '$routeParams', 'common', 'datacontext']; 

    function dataProviderDetail($scope, $location, $routeParams, common, datacontext) {

        $scope.title = 'Data Provider Detail';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logSuccess = getLogFn(controllerId, 'success');
        var logError = getLogFn(controllerId, 'error');

        $scope.format = 'MMMM Do YYYY, h:mm:ss a';

        $scope.users = [

        { name: 'Al' },
        { name: 'user2' },
        { name: 'user3' }
        ];

        //Defaulted postion for toggle-switch
        $scope.switch = 'false';
        $scope.switchAlternate = 'Per Request';

        $scope.toggle = function(state) {

            (state == 'true') ? $scope.switch = 'false' : $scope.switch = 'true';
            $scope.dataProvider.response[0].fieldLevelCostPriceOverride = $scope.switch;
            $scope.dataProvider.response[0].costOfSale = 0;
        }

        $scope.selectedGroupIndustry = {};

        $scope.updateFieldIndustry = function (groupIndustry) {

            var provider = null;

            try {

                provider = $scope.dataProvider.response;
            } catch (e) {

                //console.log(e.message);
            }

            if (provider != null) {

                for (var i = 0; i < provider.length; i++) {

                    var providerItem = provider[i];

                    for (var x = 0; x < (providerItem.dataFields).length; x++) {

                        providerItem.dataFields[x].industry = groupIndustry;
                    }

                }
            }
        }

        $scope.total = function () {

            var valueTotal = 0;
            var items = null;

            try {

                items = $scope.dataProvider.response;
            } catch (e) {

                //console.log(e.message);
            }

            if (items != null) {

                for (var i = 0; i < items.length; i++) {

                    var listItem = items[i];

                    for (var x = 0; x < (listItem.dataFields).length; x++) {

                        valueTotal += listItem.dataFields[x].price;
                    }

                }
            }

            $scope.dataProvider.response[0].costOfSale = valueTotal;
            return valueTotal;
        };


        $scope.editProvider = function (providerData) {

            return datacontext.editDataProvider($routeParams.id, providerData).then(function(response) {

                console.log(response);
                (response.status === 200) ? logSuccess('Data Provider edited!') : logError('Error 404. Please check your connection settings');


            });
        };

        $scope.cancel = function () {

            $location.path('/data-providers');
        };

        activate();

        function activate() {

            common.activateController([getDataProvider($routeParams.id, $routeParams.version), getIndustries()], controllerId)
                .then(function () {
                    log('Activated Data Providers Edit View');              
            });
        }

        function getDataProvider(id, version) {

            return datacontext.getDataProvider(id, version).then(function (response) {

                $scope.dataProvider = response.data;
            });
        }

        function getIndustries() {

            return datacontext.getIndustries().then(function (response) {

                $scope.industries = response;
            });
        }
    }
})();

