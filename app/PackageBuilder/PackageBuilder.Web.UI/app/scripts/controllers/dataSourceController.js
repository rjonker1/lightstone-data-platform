'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('dsCtrl', ['$scope', '$http', 'GetAPI', 'PostAPI', function ($scope, $http, GetAPI, PostAPI) {
    
    $scope.message = "Loading data from API";
    //$scope.test = GetAPI.query();



   $scope.createProvider = function(providerData) {

      $scope.message = "Saving data..."
      PostAPI.save({}, providerData);
      $scope.message = "Data was successfully saved"

      }

    $scope.loadDProvider = function() {
      
      $scope.test = GetAPI.query();

      GetAPI.get(function(data){

           var resp = data.response;
           alert(resp);
           

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

    }
  
    

  }]);