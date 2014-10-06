'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:MainCtrl
 * @description
 * # MainCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('dsCtrl', ['$scope', '$location', 'GetDataProviders', function ($scope, $location, GetDataProviders) {
    

    GetDataProviders.query(function(data){

       var resp = data.response;
          
           for( var res in resp)
           {

              /*alert(''+res);*/
              if (resp.hasOwnProperty(res)) {
                                                
                  $scope.test = resp;
                  $scope.myData = resp;
                  $scope.message = "Data Loaded."
              }
          }

    }, function(err){

        alert("Error");
    }); 
  
    /*$scope.myData = [
                     {id: 'test-123', name: 'Kyle Hayhurst', age: 25, interest: 'Javascript'},
                     {id: 'test-123', name: 'Jimmy Hampton', age: 25, interest: 'HTML'},
                     {id: 'test-123', name: 'Tim Sweet', age: 27, interest: 'HTML'},
                     {id: 'test-123', name: 'Jonathon Ricaurte', age: 29, interest: 'CSS'},
                     {id: 'test-123', name: 'Brian Hann', age: 28, interest: 'PHP'},
                     {id: 'test-123', name: 'Jimmy Hampton', age: 25, interest: 'HTML'},
                     {id: 'test-123', name: 'Tim Sweet', age: 27, interest: 'HTML'},
                     {id: 'test-123', name: 'Jonathon Ricaurte', age: 29, interest: 'CSS'},
                     {id: 'test-123', name: 'Brian Hann', age: 28, interest: 'PHP'},
                     {id: 'test-123', name: 'Jimmy Hampton', age: 25, interest: 'HTML'},
                     {id: 'test-123', name: 'Tim Sweet', age: 27, interest: 'HTML'},
                     {id: 'test-123', name: 'Jonathon Ricaurte', age: 29, interest: 'CSS'},
                     {id: 'test-123', name: 'Brian Hann', age: 28, interest: 'PHP'},
                     {id: 'test-123', name: 'Jimmy Hampton', age: 25, interest: 'HTML'},
                     {id: 'test-123', name: 'Tim Sweet', age: 27, interest: 'HTML'},
                     {id: 'test-123', name: 'Jonathon Ricaurte', age: 29, interest: 'CSS'},
                     {id: 'test-123', name: 'Brian Hann', age: 28, interest: 'PHP'} 
    ];*/

    $scope.notify = function(row) {

        $location.path('/data-source-detail/'+row.entity.id);
    }

    $scope.selectedDatasource = [];

    $scope.gridOptions = { 
        data: 'myData',
        selectedItems: $scope.selectedDatasource,
        multiSelect: false,
        enablePaging: true,
        showFilter: true,
        showGroupPanel: true,
        columnDefs: [
            {field: 'name', displayName: 'Name'},
            {field: 'description', displayName: 'Description'},
            {field: 'owner', displayName: 'Owner'},
            {field: 'created', displayName: 'Created'},
            {field: 'edited', displayName: 'Edited'},
            {field: 'version', displayName: 'Version'},
            {displayName: '', cellTemplate: '<input type="button" name="edit" ng-click="notify(row)" value="Edit" />'}
        ]
    };

  }]);