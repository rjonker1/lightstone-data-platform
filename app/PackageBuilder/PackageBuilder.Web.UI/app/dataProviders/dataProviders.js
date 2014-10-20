(function () {
    'use strict';

    var controllerId = "dataProviders";

    angular
        .module('app')
        .controller(controllerId, dataSources);

    dataSources.$inject = ['$scope', 'common', 'datacontext'];

    function dataSources($scope, common, datacontext) {

        $scope.title = 'Data Providers';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        $scope.test = '';

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


        $scope.selectedDatasource = [];

        $scope.gridOptions = {
            data: 'myData',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: true,
            showFilter: true,
            showGroupPanel: true,
            columnDefs: [
                { field: 'Name', displayName: 'Name', filter: { term: '' } },
                { field: 'description', displayName: 'Description' },
                { field: 'owner', displayName: 'Owner' },
                { field: 'created', displayName: 'Created' },
                { field: 'edited', displayName: 'Edited' },
                { field: 'version', displayName: 'Version' },
                { displayName: '', cellTemplate: '<input type="button" name="edit" ng-click="notify(row)" value="Edit" />' }
            ]
        };



        activate();

        function activate() {
            
            common.activateController([getDataProviders()], controllerId)
                .then(function () { log('Activated Data Providers View'); });
        }

        function getDataProviders() {
            
            return datacontext.getDataProviders().then(function (data) {

                (data.indexOf('Error') > -1) ? (logError(data) ? $scope.test = null : $scope.test = data) : log('Data loaded successfully!');
        
            });
        }
    }
})();
