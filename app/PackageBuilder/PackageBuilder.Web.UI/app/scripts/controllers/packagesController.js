'use strict';

angular.module('packageBuilderwebuiApp')
  .controller('packagesCtrl', ['$scope', '$location', '$filter', 'GetPackages', 'ngTableParams', function ($scope, $location, $filter, GetPackages, ngTableParams) {

 
  	GetPackages.query(function(data){

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


$scope.navigate = function(row) {

        $location.path('/package-detail/'+row.entity.dataProviderId+'/'+row.entity.version);
    }
    

$scope.selectedDatasource = [];

    $scope.gridOptions = { 
        data: 'dSourcesData',
        selectedItems: $scope.selectedDatasource,
        multiSelect: false,
        enablePaging: true,
        enableFiltering: true,
        showFilter: true,
        showGroupPanel: true,
        columnDefs: [
            {field: 'name', displayName: 'Name'},
            {field: 'description', displayName: 'Description'},
            {field: 'owner', displayName: 'Owner'},
            {field: 'created', displayName: 'Created'},
            {field: 'edited', displayName: 'Edited'},
            {field: 'version', displayName: 'Version'},
            {displayName: '', cellTemplate: '<input type="button" name="edit" ng-click="navigate(row)" value="Edit" />'}
        ]
    };



    /*$scope.tableParams = new ngTableParams({
        page: 1,            // show first page
        count: 10,          // count per page
        filter: {
            name: 'M'       // initial filter
        }
    }, {
        total: data.length, // length of data
        getData: function($defer, params) {
            // use build-in angular filter
            var orderedData = params.filter() ?
                   $filter('filter')(data, params.filter()) :
                   data;

            $scope.users = orderedData.slice((params.page() - 1) * params.count(), params.page() * params.count());

            params.total(orderedData.length); // set total for recalc pagination
            $defer.resolve($scope.users);
        }
    });*/

  }]);
