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
    
    $scope.dataProvs = [{
                          "name": "Loading Data...",
                          "fields": [
                          {
                              "name": "Loading Data...",
                          }]
                        }];

    $http({
        method: 'GET',
        url: 'http://dev.lightstone.packagebuilder.api/getDataProviders'
        }).success(function(data, status, headers, config) {
            $scope.dataProvs = data;

        }).error(function(data, status, headers, config) {
          
            $scope.dataProvs = [{
                          "name": "Error Loading Data...",
                          "fields": [
                          {
                              "name": "Error Loading Data...",
                          }]
                        }];
        });

  } );