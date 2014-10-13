'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('dsDetailCtrl', ['$rootScope', '$routeParams', '$route', '$scope', 'GetDataProvider', 'PostDataProvider', function ($rootScope, $routeParams, $route, $scope, GetDataProvider, PostDataProvider) {
    

    $scope.dataProvider = {};

    $scope.alerts = [

            { msg: 'Loading Data...' }
    ];

    GetDataProvider.get({ id: $routeParams.id, version: $routeParams.version }, function(data){

           var resp = data.response;
          
           for( var res in resp)
           {

              /*alert(''+res);*/
              if (resp.hasOwnProperty(res)) {
                                                
                  $scope.dataProvider = resp;            
              }
            }

            $scope.alerts = [

              { type: 'success', msg: 'Data loaded successfully !' }
            ];

            $scope.today();

      }, function(err){

          $scope.alerts = [

            { type: 'danger', msg: 'Failed to communicate with webserver !' }
          ];
      });
    

    $scope.createProvider = function(providerData) {

      $scope.message = "Saving data..."

      PostDataProvider.save({ id:$scope.dataProvider.id }, providerData, function(data) {

        //var resp = data.msg;
         
        $scope.alerts = [

              { type: 'success', msg: 'DataProvider: '+$scope.dataProvider.name+' saved successfully !' }
            ];

      }, function(err){

        $scope.message = "Error saving Data Provider";
      });

    }



    $scope.today = function() {

        $scope.dataProvider.edited = new Date();    
    };

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

      $scope.today(); //Set dt to maintain local time model, avoid UTC!

      $scope.opened = true;
    };

    $scope.dateOptions = {
      formatYear: 'yy',
      startingDay: 1
    };

    $scope.users = [

          {name:'user1'},
          {name:'user2'},
          {name:'user3'}
    ];

    $scope.states = [

          {name:'Under Construction'},
          {name:'Published'},
          {name:'Expired'}
    ];

    $scope.formats = ['dd-MMMM-yyyy', 'yyyy/MM/dd', 'dd-MM-yyyy', 'shortDate', 'yyyy-MM-ddTHH:mm:ss'];
    $scope.format = $scope.formats[4];

    $scope.updateAPIModel = function(data){

        alert(data);
    }

  }]);