(function () {
    'use strict';

    var controllerId = 'dataProviderDetail';

    angular
        .module('app')
        .controller(controllerId, dataProviderDetail);

    dataProviderDetail.$inject = ['$scope', 'common', 'datacontext']; 

    function dataProviderDetail($scope, common, datacontext) {

        $scope.title = 'Data Provider Detail';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logSuccess = getLogFn(controllerId, 'success');
        var logError = getLogFn(controllerId, 'error');

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


            //PostDataProvider.save({ id: $scope.dataProvider.id }, providerData, function (data) {

            //    //var resp = data.msg;

            //    $scope.alerts = [

            //          { type: 'success', msg: 'DataProvider: ' + $scope.dataProvider.name + ' saved successfully !' }
            //    ];

            //}, function (err) {

            //    $scope.message = "Error saving Data Provider";
            //});

        }

        activate();

        function activate() {

            common.activateController([getDataProvider()], controllerId)
                .then(function () { log('Activated Data Providers View'); });
        }

        function getDataProvider() {

            return datacontext.getDataProvider().then(function (data) {

                (data.indexOf('Error') > -1) ? logError(data) : (($scope.dProvidersData = data) ? logSuccess('Data Provider data loaded successfully!') : '');

            });
        }
    }
})();
