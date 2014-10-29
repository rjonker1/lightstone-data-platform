(function () {
    'use strict';

    var controllerId = "dataProviders";

    angular
        .module('app')
        .controller(controllerId, dataSources);

    dataSources.$inject = ['$scope', '$location', 'common', 'datacontext'];

    function dataSources($scope, $location, common, datacontext) {

        $scope.title = 'Data Providers';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.test = '';
        $scope.dProvidersData = '';

        $scope.notify = function (row) {

            $location.path('/data-provider-detail/' + row.entity.dataProviderId + '/' + row.entity.version);
        }

        $scope.selectedDatasource = [];

        $scope.gridOptions = {
            data: 'dProvidersData',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: true,
            showFilter: true,
            showGroupPanel: true,
            columnDefs: [
                { field: 'name', displayName: 'Name', filter: { term: '' } },
                { field: 'description', displayName: 'Description' },
                { field: 'owner', displayName: 'Owner' },
                { field: 'createdDate', displayName: 'Created Date' },
                { field: 'editedDate', displayName: 'Edited Date' },
                { field: 'version', displayName: 'Version' },
                { displayName: '', cellTemplate: '<input type="button" class="btn btn-success grid-btn" name="edit" ng-click="notify(row)" value="Edit" />' }
            ]
        };



        activate();

        function activate() {
            
            common.activateController([getAllDataProviders()], controllerId)
                .then(function () { log('Activated Data Providers View'); });
        }

        function getAllDataProviders() {
            
            return datacontext.getAllDataProviders().then(function (data) {

                $scope.test = data;

                (data.indexOf('Error') > -1) ? logError(data) : (($scope.dProvidersData = data) ? logSuccess('Data Providers retrieved.') : '');
        
            });
        }
    }
})();
