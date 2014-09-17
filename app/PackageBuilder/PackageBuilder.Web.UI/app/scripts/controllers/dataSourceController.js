'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('dsCtrl', function ($scope, $http) {
    
    $scope.dataProvs = [];

    $http({
        method: 'GET',
        url: 'http://dev.lightstone.packagebuilder.api/getDataProviders'
        }).success(function(data, status, headers, config) {
            $scope.dataProvs = data;

        }).error(function(data, status, headers, config) {
          
            $scope.dataProvs = [
            {
              "name": "ErrorReturnData",
            }
            ];
        });

  } );