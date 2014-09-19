'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:pkgCtrl
 * @description
 * # pkgCtrl
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

    $scope.toggle = function(scope) {
      scope.toggle();
    };

    $scope.moveLastToTheBegginig = function () {
      var a = $scope.data.pop();
      $scope.data.splice(0,0, a);
    };

    $scope.collapseAll = function() {
      $scope.$broadcast('collapseAll');
    };

    $scope.expandAll = function() {
      $scope.$broadcast('expandAll');
    };


  } );

