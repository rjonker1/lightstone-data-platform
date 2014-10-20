(function () {
    'use strict';

    var controllerId = 'packages';

    angular
        .module('app')
        .controller(controllerId, packages);

    packages.$inject = ['$scope', '$location', 'common', 'datacontext'];

    function packages($scope, $location, common, datacontext) {

        $scope.title = 'Packages';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        $scope.test = '';
        $scope.dPackagesData = '';

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

            //$location.path('/data-source-detail/' + row.entity.dataProviderId + '/' + row.entity.version);
            $location.path('/');
        }

        $scope.selectedDatasource = [];

        $scope.gridOptions = {
            data: 'dPackagesData',
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
                { displayName: '', cellTemplate: '<input type="button" class="btn btn-success grid-btn" name="edit" ng-click="notify(row)" value="Edit" />' }

            ]
        };


        activate();

        function activate() {

            common.activateController([getAllPackages()], controllerId)
                .then(function() { log('Activated Data Providers View'); });
        }

        function getAllPackages() {

            return datacontext.getAllPackages().then(function (data) {

                (data.indexOf('Error') > -1) ? logError(data) : $scope.dPackagesData = data;

            });
        }
    }
})();
