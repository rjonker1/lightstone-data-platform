(function () {
    'use strict';

    var controllerId = "dataProviders";

    angular
        .module('app')
        .controller(controllerId, dataSources);

    dataSources.$inject = ['$scope', '$location', 'uiGridConstants', 'common', 'datacontext'];

    function dataSources($scope, $location, uiGridConstants, common, datacontext) {

        $scope.title = 'Data Providers';

        $scope.$scope = $scope; //ui-grid
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.test = '';
        $scope.dProvidersData = '';
        $scope.latestVersion = 0;

        $scope.notify = function (row) {
            console.log(row);
            $location.path('/data-provider-detail/' + row.entity.dataProviderId + '/' + row.entity.version);
        };

        $scope.viewDataProvider = function (row) {
            console.log(row);
            $location.path('/data-provider-view/' + row.entity.dataProviderId + '/' + row.entity.version);
        }

        $scope.canEdit = function () {

        };

        $scope.selectedDatasource = [];
        $scope.gridOptions = {
            data: 'dProvidersData',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: false,
            showFilter: true,
            showGroupPanel: true,
            columnDefs: [
            { field: 'name', displayName: 'Name' },
            { field: 'description', displayName: 'Description' },
            { field: 'owner', displayName: 'Owner' },
            { field: 'createdDate', displayName: 'Created Date' },
            {
                field: 'editedDate',
                displayName: 'Edited Date',
                sort: {
                    direction: uiGridConstants.ASC,
                    priority: 0
                }
            },
           { field: 'version', displayName: 'Version' },

     {
         name: ' ',
         displayName: ' ',
         width: 280,
         cellTemplate: '<div ng-if="getExternalScopes().latestVersion.Get(row.entity.dataProviderId) == row.entity.version">' +
             '<input type="button" class="btn btn-success grid-btn" name="edit" ng-click="getExternalScopes().notify(row)" value="Edit" />' +
             '<input type="button" class="btn btn-defualt grid-btn" name="clone" ng-click="" value="Clone" />' +
             '<input type="button" class="btn btn-danger grid-btn" style="width: 100px;" name="remove" ng-click="" value="Remove" /></div>' +
             '' +
             '<div ng-if="getExternalScopes().latestVersion.Get(row.entity.dataProviderId) != row.entity.version">' +
             '<input type="button" class="btn btn-info grid-btn" name="view" ng-click="getExternalScopes().viewDataProvider(row)" value="View" /></div>'
     }
            ]
        };



        activate();

        function activate() {

            common.activateController([getAllDataProviders()], controllerId)
                .then(function () { log('Activated Data Providers View'); });
        }

        function getAllDataProviders() {

            return datacontext.getAllDataProviders().then(function (data) {

                var distinctProviders = Enumerable.From(data)
                    .Distinct(function (x) {
                        return x.dataProviderId;
                    })
                    .Select(function (x) {
                        return x.dataProviderId;
                    });

                $scope.latestVersion = Enumerable.From(distinctProviders)
                    .ToDictionary(function (x) {
                        return x;
                    }, function (id) {
                        return Enumerable.From(data).Where(function (x) {
                            return x.dataProviderId == id;
                        }).Max(function (x) {
                            return x.version;
                        });
                    });

                (data.indexOf('Error') > -1) ? logError(data) : (($scope.dProvidersData = data) ? logSuccess('Data Providers retrieved.') : '');

            });
        }
    }
})();
