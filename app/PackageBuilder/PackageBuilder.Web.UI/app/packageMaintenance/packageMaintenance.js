(function () {
    'use strict';

    var controllerId = 'packageMaintenance';

    angular
        .module('app')
        .controller(controllerId, packageMaintenance);

    packageMaintenance.$inject = ['$scope', '$http', 'common', 'datacontext'];

    function packageMaintenance($scope, $http, common, datacontext) {

        $scope.title = 'packageMaintenance';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        //MOCK
        $http({
            method: 'GET',
            url: '/DataProviders.json'
            }).success(function(data, status, headers, config) {
                
               $scope.dataProvsPkg = data;
    
            }).error(function(data, status, headers, config) {
              
             
            });

        activate();

        function activate() {
            
            common.activateController([getDataProviders()], controllerId)
               .then(function () { log('Activated Package Maintenance View'); });
        }

        function getDataProviders() {

            //return datacontext.getDataProviders().then(function (data) {

                //(data.indexOf('Error') > -1) ? (logError(data) ? $scope.test = null : $scope.test = data) : log('Data loaded successfully!');

           // });
        }
    }
})();
