(function () {
    'use strict';

    var controllerId = 'packages';

    angular
        .module('app')
        .controller(controllerId, packages);

    packages.$inject = ['$scope', '$modal', '$location', 'uiGridConstants', 'common', 'datacontext'];

    function packages($scope, $modal, $location, uiGridConstants, common, datacontext) {

        $scope.title = 'Packages';

        $scope.$scope = $scope; //ui-grid

        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');

        $scope.test = '';
        $scope.dPackagesData = '';

        $scope.notify = function (row) {

            $location.path('/package-maintenance-edit/' + row.entity.packageId + '/' + row.entity.version);
        }

        $scope.viewPackage = function (row) {

            $location.path('/package-maintenance-view/' + row.entity.packageId + '/' + row.entity.version);
        }

        $scope.selectedDatasource = [];

        $scope.items = ['item1', 'item2', 'item3'];

        $scope.open = function (packageName, packageId) {

            var modalInstance = $modal.open({
                templateUrl: 'myModalContent.html',
                controller: 'ModalInstanceCtrl',
                //size: size,
                resolve: {
                    items: function () {
                        return $scope.items;
                    },
                    packageName: function () {
                        return packageName;
                    },
                    packageId: function () {
                        return packageId;
                    }
                }
            });

            //TODO: Refresh dataGrid after clone of Package
            modalInstance.result.then(function () {

                getAllPackages();
            }, function () {
                //$log.info('Modal dismissed at: ' + new Date());
                //getAllPackages();
            });


        };

        $scope.gridOptions = {
            data: 'dPackagesData',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: false,
            showFilter: true,
            showGroupPanel: true,
            columnDefs: [
            { field: 'name', displayName: 'Name', filter: { term: '' } },
                { field: 'description', displayName: 'Description' },
                { field: 'owner', displayName: 'Owner' },
                { field: 'createdDate', displayName: 'Created' },
                {
                    field: 'editedDate',
                    displayName: 'Edited Date',
                    sort: {
                        direction: uiGridConstants.ASC,
                        priority: 0
                    }
                },
                { field: 'state.alias', displayName: 'State' },
                { field: 'displayVersion', displayName: 'Version', filter: { term: '' } },
         {
             name: ' ',
             displayName: ' ',
             width: 280,
             cellTemplate: '<div ng-if="getExternalScopes().latestVersion.Get(row.entity.packageId) == row.entity.version">' +
                 '<input type="button" class="btn btn-success grid-btn" name="edit" ng-click="getExternalScopes().notify(row)" value="Edit" />' +
                 '<input type="button" class="btn btn-defualt grid-btn" name="clone" ng-click="getExternalScopes().open(row.entity.name, row.entity.packageId)" value="Clone" />' +
                 '<input type="button" class="btn btn-danger grid-btn" style="width: 100px;" name="remove" ng-click="" value="Remove" /></div>' +
                 '' +
                 '<div ng-if="getExternalScopes().latestVersion.Get(row.entity.packageId) != row.entity.version">' +
                 '<input type="button" class="btn btn-info grid-btn" name="view" ng-click="getExternalScopes().viewDataProvider(row)" value="View" /></div>'
         }
            ]
        };


        activate();

        function activate() {

            common.activateController([getAllPackages()], controllerId)
                .then(function () { log('Activated Data Providers View'); });
        }

        function getAllPackages() {

            return datacontext.getAllPackages().then(function (result) {

                var distinctProviders = Enumerable.From(result)
                    .Distinct(function (x) {
                        return x.packageId;
                    })
                    .Select(function (x) {
                        return x.packageId;
                    });

                $scope.latestVersion = Enumerable.From(distinctProviders)
                    .ToDictionary(function (x) {
                        return x;
                    }, function (id) {
                        return Enumerable.From(result).Where(function (x) {
                            return x.packageId == id;
                        }).Max(function (x) {
                            return x.version;
                        });
                    });

                (result.indexOf('Error') > -1) ? logError(result) : $scope.dPackagesData = result;
            });
        }
    }
})();
