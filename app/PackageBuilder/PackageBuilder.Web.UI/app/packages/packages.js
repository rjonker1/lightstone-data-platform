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
        var logSuccess = getLogFn(controllerId, 'success');
        var logError = getLogFn(controllerId, 'error');

        $scope.test = '';
        $scope.dPackagesData = '';

        $scope.notify = function(row) {
            $location.path('/package-maintenance-edit/' + row.entity.packageId + '/' + row.entity.version);
        };

        $scope.viewPackage = function(row) {
            $location.path('/package-maintenance-view/' + row.entity.packageId + '/' + row.entity.version);
        };

        $scope.removePkg = function(id) {
            deletePackage(id);
        };

        $scope.selectedDatasource = [];
        
        // Defaulted postion for toggle-switch
        $scope.switch = 'false';
        $scope.switchAlternate = 'Show New';
        $scope.toggle = function (state) {
            (state == true) ? $scope.switch = false : $scope.switch = true;
            $scope.dPackagesData = getAllPackages(state);
        };

        $scope.items = ['item1', 'item2', 'item3'];

        $scope.clone = function (packageName, packageId) {
            var modalInstance = $modal.open({
                templateUrl: 'app/viewTemplates/pkgCloneModalTemplate.html',
                controller: 'PkgCloneModalInstanceCtrl',
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

            modalInstance.result.then(function () {
                getAllPackages();
            }, function () {
                //$log.info('Modal dismissed at: ' + new Date());
            });
        };

        $scope.delete = function (packageName, packageId) {
            var modalInstance = $modal.open({
                templateUrl: 'app/viewTemplates/pkgDeleteModalTemplate.html',
                controller: 'PkgDeleteModalInstanceCtrl',
                //size: size,
                resolve: {
                    packageName: function () {
                        return packageName;
                    },
                    packageId: function () {
                        return packageId;
                    }
                }
            });

            modalInstance.result.then(function () {
                getAllPackages();
            }, function () {
                //$log.info('Modal dismissed at: ' + new Date());
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
                 '<input type="button" class="btn btn-defualt grid-btn" name="clone" ng-click="getExternalScopes().clone(row.entity.name, row.entity.packageId)" value="Clone" />' +
                 '<input type="button" class="btn btn-danger grid-btn" style="width: 100px;" name="remove" ng-click="getExternalScopes().delete(row.entity.name, row.entity.packageId)" value="Remove" /></div>' +
                 '' +
                 '<div ng-if="getExternalScopes().latestVersion.Get(row.entity.packageId) != row.entity.version">' +
                 '<input type="button" class="btn btn-info grid-btn" name="view" ng-click="getExternalScopes().viewPackage(row)" value="View" /></div>'
         }
            ]
        };

        activate();

        function activate() {
            common.activateController([getAllPackages()], controllerId)
                .then(function () { log('Activated Data Providers View'); });
        }

        function getAllPackages(showAll) {
            return datacontext.getAllPackages(showAll).then(function (result) {
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
                reSize(result.length);
            }, function (error) {
                logError(error.data.errorMessage);
            });
        }
        
        function reSize(rows) {
            // This will adjust the css after the Data is loaded
            var newHeight = (rows * 30) + 80;
            angular.element(document.getElementById('dsGrid')).css('height', newHeight + 'px');
        };
    }
})();
