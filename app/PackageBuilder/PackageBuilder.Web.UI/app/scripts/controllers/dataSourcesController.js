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


    $scope.alerts = [

            { msg: 'Loading Data...' }
    ];
    

    GetDataProviders.query(function(data){

       var resp = data.response;
          
           for( var res in resp)
           {

              if (resp.hasOwnProperty(res)) {
                                                              
                  $scope.dSourcesData = resp;
                  $scope.message = "Data Loaded."
              }
          }

          $scope.alerts = [

            { type: 'success', msg: 'Data loaded successfully !' }
          ];

    }, function(err){

        $scope.alerts = [

            { type: 'danger', msg: 'Failed to communicate with webserver !' }
        ];

    }); 

    $scope.notify = function(row) {

        $location.path('/data-source-detail/'+row.entity.dataProviderId+'/'+row.entity.version);
    }

    $scope.selectedDatasource = [];

    $scope.gridOptions = { 
        data: 'dSourcesData',
        selectedItems: $scope.selectedDatasource,
        multiSelect: false,
        enableFiltering: true,
        showFilter: true,
        showGroupPanel: true,
        columnDefs: [
            {field: 'name', displayName: 'Name', filter: { term: ''} },
            {field: 'description', displayName: 'Description'},
            {field: 'owner', displayName: 'Owner'},
            {field: 'created', displayName: 'Created'},
            {field: 'edited', displayName: 'Edited'},
            {field: 'version', displayName: 'Version'},
            {displayName: '', cellTemplate: '<input type="button" name="edit" ng-click="notify(row)" value="Edit" />'}
        ]
    };

  }]);