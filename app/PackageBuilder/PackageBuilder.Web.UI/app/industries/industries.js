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
      
        $scope.colDefs = [
                { name: 'name', enableCellEdit: true }
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
                updateIndustry(rowEntity.id, newValue);
                console.log('edited row id:' + rowEntity.id + ' Column:' + colDef.name + ' newValue:' + newValue + ' oldValue:' + oldValue);
                $scope.$apply();
            });
        };

        function clearNewIndustry() {
            var $industry = $('#industry_add');
            $industry.val('');
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
                        logError(errorCallback.data.errorMessage);
                });
        }
            
            $scope.addIndustry = function() {
            var $industry = $('#industry_add');
            var name = $industry.val();
            if (name.length === 0) {
                clearNewIndustry();
                return;
            }

            return industryRepository.addIndustry(name).then(
                function(successCallback) {
                    clearNewIndustry();
                    getIndustries();
                    logSuccess(successCallback.response);
                }, function(errorCallback) {
                    logError(errorCallback.data.errorMessage);
                    console.log(errorCallback.data.errorMessage);

                });
        };

        function updateIndustry(id, name) {
            return industryRepository.updateIndustry(id, name).then(
                   function (successCallback) {
                        getIndustries();
                        logSuccess(successCallback.response);
                }, function(errorCallback) {
                    logError(errorCallback.data.errorMessage);
                });
        }
    }
})();
