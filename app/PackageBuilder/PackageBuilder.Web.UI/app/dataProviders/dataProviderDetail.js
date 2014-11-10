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

        $scope.users = [

        { name: 'Al' },
        { name: 'user2' },
        { name: 'user3' }
        ];

        $scope.format = 'MMMM Do YYYY, h:mm:ss a';

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

                console.log(response.data);
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

