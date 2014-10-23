(function() {
    'use strict';

    var controllerId = "industries";

    angular
        .module('app')
        .controller(controllerId, industries);

    industries.$inject = ['$scope', '$http', '$location', 'common', 'industryRepository'];

    function industries($scope, $http, $location, common, industryRepository) {

        $scope.title = 'Industries';
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
                { headerCellTemplate: 'app/industries/headerTemplate.html', field: 'name', displayName: 'Name', filter: { term: '' } }
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
            updateIndustry(entity.id, entity.name);
        });
        
        $scope.showIndustryAddInput = function () {
            var $industry = $('#industry_add');
            $industry.attr('ng-show', true);
            $industry.removeClass('ng-hide');
            $industry.addClass('ng-show');
        };

        function hideIndustryAddInput() {
            var $industry = $('#industry_add');
            $industry.attr('ng-show', false);
            $industry.removeClass('ng-show');
            $industry.addClass('ng-hide');
        }

        activate();

        function activate() {
            common.activateController([getIndustries()], controllerId)
                .then(function() { log('Activated Industries View'); });
        }

        function getIndustries() {
            return industryRepository.getIndustries().then(
                   function(successCallback) {
                        $scope.data = successCallback;
                        logSuccess("Industries retrieved");
                }, function(errorCallback) {
                        logError(errorCallback.response);
                });
        }

        $scope.addIndustry = function(row, $event) {
            var $industry = $('#industry_add');
            var name = $industry.val();
            if (name.length === 0) {
                hideIndustryAddInput();
                return;
            }
                
            return industryRepository.addIndustry(name).then(
                   function(successCallback) {
                        hideIndustryAddInput();
                        getIndustries();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                        logError(errorCallback);
                });
        };

        function updateIndustry(id, name) {
            return industryRepository.updateIndustry(id, name).then(
                   function (successCallback) {
                        getIndustries();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                        logError(errorCallback.response);
                });
        }
    }
})();
