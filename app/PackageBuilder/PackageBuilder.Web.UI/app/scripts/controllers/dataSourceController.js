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


      $scope.dataProvider = {'name': 'test'};

      PostAPI.save({}, $scope.dataProvider);

        /*$http.post("http://localhost:12257/DataProvider/AddTest", providerData, {
              headers: { 'Content-Type': 'application/json'},

        }).success(function(data) {

              $scope.test = data;
        });*/


        /*$http({

          method: "POST",
          url: "http://localhost:12257/DataProvider/AddTest",
          data: providerData
        }).success(function(data){

              $scope.test = data;

        });*/
    }

    $scope.loadDProvider = function() {
      
      $scope.test = GetAPI.query();

      /*GetAPI.get(function(data){

           var resp = data.response;
           alert(resp);
           

           for( var res in resp)
           {

              /*alert(''+res);
              if (resp.hasOwnProperty(res)) {
                                                
                  $scope.dataProvider = resp;
                  $scope.message = "Data Loaded."


              }
          }

      }, function(err){

          alert('There was an issue contacting the API')
      });*/

      /*$http({
        method: 'GET',
        url: 'http://localhost:12257/DataProvider/Get/1b9c9ed5-c317-46af-9a7c-f51499c21d26'
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
      }*/
    }
    

  }]);