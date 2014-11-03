(function () {
    'use strict';

    var controllerId = 'dataProviderDetail';

    angular
        .module('app')
        .controller(controllerId, dataProviderDetail);

    dataProviderDetail.$inject = ['$scope', '$routeParams', 'common', 'datacontext']; 

    function dataProviderDetail($scope, $routeParams, common, datacontext) {

        $scope.title = 'Data Provider Detail';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logSuccess = getLogFn(controllerId, 'success');
        var logError = getLogFn(controllerId, 'error');

        //$scope.dataProvider = { "name": "qwe", "description": "qweqweqweqweqweqweqwe" }

        $scope.now = moment().format('MMMM Do YYYY, h:mm:ss a');

        $scope.users = [

         { name: 'user1' },
         { name: 'user2' },
         { name: 'user3' }
        ];

      
        $scope.states = [

              { name: 'Under Construction' },
              { name: 'Published' },
              { name: 'Expired' }
        ];

        $scope.createProvider = function (providerData) {

            //
            //Functionality to post to API
            //

            return datacontext.editDataProvider($routeParams.id, providerData).then(function (response) {

                console.log(response);
                 (response.status === 200) ? logSuccess('Data Provider edited!') : logError('Error 404. Please check your connection settings');
                

            });

        }

        activate();

        function activate() {

            common.activateController([getDataProvider($routeParams.id, $routeParams.version)], controllerId)
                .then(function () {
                    log('Activated Data Providers Edit View');              
            });
        }

        function getDataProvider(id, version) {

            return datacontext.getDataProvider(id, version).then(function (response) {

                console.log(response.data);
                $scope.dataProvider = response.data;

                //(data.indexOf('Error') > -1) ? logError(data) : (($scope.dProvidersData = data) ? logSuccess('Data Providers retrieved.') : '');
            });
        }
    }
})();
