'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('dsCtrl', ['$scope', '$http', 'GetDataProviders', function ($scope, $http, GetDataProviders) {
    
  
    //$scope.loadDProviders = function() {
      
      $scope.test = GetDataProviders.query();

      GetDataProviders.get(function(data){

           var resp = data.response;
          
           for( var res in resp)
           {

              /*alert(''+res);*/
              if (resp.hasOwnProperty(res)) {
                                                
                  $scope.dataProvider = resp;
                  $scope.message = "Data Loaded."
              }
          }

      }, function(err){

          alert('There was an issue contacting the API')
      });

    //}

  }]);