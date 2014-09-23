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
    
    $scope.message = "Loading data from API";

    $http({
        method: 'GET',
        url: 'http://localhost:12257/DataProvider/Get/9c1652c3-1f00-44df-99fb-5ef5d91a47ec'
        }).success(function(data, status, headers, config) {
            
          for( var res in data)
          {
              if (data.hasOwnProperty(res)) {
                                                
                  $scope.test = data[res];
                  $scope.dataProvider = data[res];
                  $scope.message = "Data Loaded."
              }
          }


        }).error(function(data, status, headers, config) {
          
            $scope.message = "Error loading data from API";
        });

    $scope.createProvider = function(providerData) {
        $http({

          method: "post",
          url: "http://dev.lightstone.packagebuilder.api/DataProvider/AddTest",
          data: providerData
        }).success(function(data){

              $scope.test = data;

        });
    }

  } );