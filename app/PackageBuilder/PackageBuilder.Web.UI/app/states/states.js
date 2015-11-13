(function() {
    'use strict';

    var controllerId = "states";

    angular
        .module('app')
        .controller(controllerId, states);

    states.$inject = ['$scope', '$http', '$location', 'common', 'stateRepository'];

    function states($scope, $http, $location, common, stateRepository) {

        $scope.title = 'States';
        var getLogFn = common.logger.getLogFn;
        var log = getLogFn(controllerId);
        var logError = getLogFn(controllerId, 'error');
        var logSuccess = getLogFn(controllerId, 'success');

        $scope.data = [];
        $scope.notify = function(row) {
            //$location.path('/data-source-detail/' + row.entity.dataProviderId + '/' + row.entity.version);
        };
        
        $scope.colDefs = [
                { name: 'name', enableCellEdit: false },
                { field: 'alias', displayName: 'Alias' }
        ];
        $scope.gridOptions = {
            data: 'data',
            multiSelect: false,
            columnDefs: $scope.colDefs
        };

        $scope.gridOptions.onRegisterApi = function (gridApi) {
            //set gridApi on scope
            $scope.gridApi = gridApi;
            gridApi.edit.on.afterCellEdit($scope, function (rowEntity, colDef, newValue, oldValue) {
                updateState(rowEntity.id, rowEntity.name, rowEntity.alias);
                console.log('edited row id:' + rowEntity.id + ' Column:' + colDef.name + ' newValue:' + newValue + ' oldValue:' + oldValue);
                $scope.$apply();
            });
        };

        function clearNewIndustry() {
            var $industry = $('#state_add');
            $industry.val('');
        }

        activate();

        function activate() {
            common.activateController([getStates()], controllerId)
                .then(function() { log('Activated States View'); });
        }

        function getStates() {
            return stateRepository.getStates().then(
                   function(successCallback) {
                        $scope.data = successCallback;
                        logSuccess("States retrieved");
                }, function(errorCallback) {
                    logError(errorCallback.data.errorMessage);
                });
        }

        $scope.addState = function() {
            var $state = $('#state_add');
            var name = $state.val();
            if (name.length === 0) {
                clearNewIndustry();
                return;
            }
                
            return stateRepository.addState(name).then(
                   function(successCallback) {
                        clearNewIndustry();
                        getStates();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                    logError(errorCallback.data.errorMessage);
                });
        };

        function updateState(id, name, alias) {
            return stateRepository.updateState(id, name, alias).then(
                   function (successCallback) {
                        getStates();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                    logError(errorCallback.data.errorMessage);
                });
        }
    }
})();
