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

        $scope.myData = [
         {
             "Id": "1",
             "Name": "Cox",
             "lastName": "Carney",
             "company": "Enormo",
             "employed": true
         },
         {
             "Id": "2",
             "Name": "Lorraine",
             "lastName": "Wise",
             "company": "Comveyer",
             "employed": false
         },
         {
             "Id": "3",
             "Name": "Nancy",
             "lastName": "Waters",
             "company": "Fuelton",
             "employed": false
         }
        ];


        $scope.notify = function (row) {

            $location.path('/data-source-detail/' + row.entity.dataProviderId + '/' + row.entity.version);
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
                { field: 'created', displayName: 'Created' },
                { field: 'edited', displayName: 'Edited' },
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

                (data.indexOf('Error') > -1) ? logError(data) : (($scope.dProvidersData = data) ? logSuccess('Data Providers retrieved.') : '');
        
            });
        }
    }
})();
