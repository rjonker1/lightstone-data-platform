'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('pkgCtrl', function ($scope, $http) {
    
    $scope.dataProvsPkg = [{
                          'name': 'Loading Data...',
                          'fields': [
                          {
                              'name': 'Loading Data...',
                          }]
                        }];

    $http({
        method: 'GET',
        url: '/DataProviders.json'
        }).success(function(data, status, headers, config) {
            $scope.dataProvsPkg = data;

        }).error(function(data, status, headers, config) {
          
            $scope.dataProvsPkg = [{
                          'name': 'Error Loading Data...',
                          "fields": [
                          {
                              'name': 'Error Loading Data...',
                          }]
                        }];
        });

  } );