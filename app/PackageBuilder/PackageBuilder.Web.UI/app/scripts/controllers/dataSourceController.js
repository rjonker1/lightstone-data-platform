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
    
    $scope.dataProvider = {};

    $scope.createProvider = function(providerData) {

      $scope.message = "Saving data..."

      PostAPI.save({}, providerData, function(data) {

        //var resp = data.msg;
         
        $scope.message = "Data Provider was successfully saved";//+resp;

      }, function(err){

        $scope.message = "Error saving Data Provider";
      });

    }

    $scope.loadDProvider = function() {
      
      $scope.test = GetAPI.query();

      GetAPI.get(function(data){

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

    }

    $scope.today = function() {
      $scope.dt = new Date();
    };
    $scope.today();

    $scope.clear = function () {
      $scope.dt = null;
    };

    // Disable weekend selection
    $scope.disabled = function(date, mode) {
      return ( mode === 'day' && ( date.getDay() === 0 || date.getDay() === 6 ) );
    };

    $scope.toggleMin = function() {
      $scope.minDate = $scope.minDate ? null : new Date();
    };
    $scope.toggleMin();

    $scope.open = function($event) {
      $event.preventDefault();
      $event.stopPropagation();

      $scope.opened = true;
    };

    $scope.dateOptions = {
      formatYear: 'yy',
      startingDay: 1
    };

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd/MM/yyyy', 'shortDate'];
    $scope.format = $scope.formats[2];

  }]);