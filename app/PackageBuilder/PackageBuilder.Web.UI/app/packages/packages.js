﻿(function () {
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
        var logSuccess = getLogFn(controllerId, 'success');

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

        $scope.notify = function(row) {

            $location.path('/package-maintenance-edit/' + row.entity.packageId + '/' + row.entity.version);
        };

        $scope.viewPackage = function(row) {

            $location.path('/package-maintenance-view/' + row.entity.packageId + '/' + row.entity.version);
        };

        $scope.selectedDatasource = [];

        $scope.gridOptions = {
            data: 'dPackagesData',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: true,
            showFilter: true,
            showGroupPanel: true,
            columnDefs: [
                { field: 'name', displayName: 'Name', filter: { term: '' } },
                { field: 'description', displayName: 'Description' },
                { field: 'owner', displayName: 'Owner' },
                { field: 'createdDate', displayName: 'Created' },
                { field: 'editedDate', displayName: 'Edited' },
                { field: 'state.alias', displayName: 'State' },
                { field: 'displayVersion', displayName: 'Version', filter: { term: '' } },
                //{ displayName: '', cellTemplate: '<input type="button" class="btn btn-success grid-btn" name="edit" ng-click="notify(row)" value="Edit" />' }
                {
                    displayName: '',
                    width: 280,
                    cellTemplate: '<div ng-if="latestVersion.Get(row.entity.packageId) == row.entity.version">' +
                        '<input type="button" class="btn btn-success grid-btn" name="edit" ng-click="notify(row)" value="Edit" />' +
                        '<input type="button" class="btn btn-defualt grid-btn" name="clone" ng-click="" value="Clone" />' +
                        '<input type="button" class="btn btn-warning grid-btn" name="expire" ng-click="" value="Expire" />' +
                        '<input type="button" class="btn btn-danger grid-btn" style="width: 100px;" name="remove" ng-click="deletePackage(row.entity.packageId)" value="Remove" /></div>' +
                        '' +
                        '<div ng-if="latestVersion.Get(row.entity.packageId) != row.entity.version">' +
                        '<input type="button" class="btn btn-info grid-btn" name="view" ng-click="viewPackage(row)" value="View" /></div>'
                }

            ]
        };


        activate();

        function activate() {

            common.activateController([getAllPackages()], controllerId)
                .then(function() { log('Activated Data Providers View'); });
        }

        $scope.deletePackage = function(id) {
            return datacontext.deletePackage(id).then(function(response) {
                console.log(response);
                (response.status === 200) ? logSuccess('Package deleted!') : logError('Error 404. Please check your connection settings');
            });
        };

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

                $scope.dPackagesData = result;

                //(data.indexOf('Error') > -1) ? logError(data) : $scope.dPackagesData = data;

            });
        }
    }
})();
