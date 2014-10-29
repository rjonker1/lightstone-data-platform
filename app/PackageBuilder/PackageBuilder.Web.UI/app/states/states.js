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
        
        $scope.selectedDatasource = [];
        $scope.colDefs = [
                { headerCellTemplate: 'app/states/headerTemplate.html', field: 'name', displayName: 'Name', filter: { term: '' } }
        ];
        $scope.gridOptions = {
            data: 'data',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: true,
            showFilter: true,
            showGroupPanel: true,
            enableCellEditOnFocus: true,
            enableCellSelection: true,
            columnDefs: $scope.colDefs
        };

        $scope.$on('ngGridEventEndCellEdit', function(evt) {
            var entity = evt.targetScope.row.entity;
            updateState(entity.id, entity.name);
        });
        
        $scope.showStateAddInput = function () {
            var $state = $('#state_add');
            $state.attr('ng-show', true);
            $state.removeClass('ng-hide');
            $state.addClass('ng-show');
        };

        function hideStateAddInput() {
            var $state = $('#state_add');
            $state.attr('ng-show', false);
            $state.removeClass('ng-show');
            $state.addClass('ng-hide');
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
                        logError(errorCallback.response);
                });
        }

        $scope.addState = function(row, $event) {
            var $state = $('#state_add');
            var name = $state.val();
            if (name.length === 0) {
                hideStateAddInput();
                return;
            }
                
            return stateRepository.addState(name).then(
                   function(successCallback) {
                        hideStateAddInput();
                        getStates();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                        logError(errorCallback);
                });
        };

        function updateState(id, name) {
            return stateRepository.updateState(id, name).then(
                   function (successCallback) {
                        getStates();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                        logError(errorCallback.response);
                });
        }
    }
})();
