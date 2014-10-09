'use strict';

angular.module('packageBuilderwebuiApp')
  .controller('packagesCtrl', ['$scope', '$filter', 'GetDataProviders', 'ngTableParams', function ($scope, $filter, GetDataProviders, ngTableParams) {

 
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
    
  	var data = [{name: "Moroni", age: 50},
                {name: "Tiancum", age: 43},
                {name: "Jacob", age: 27},
                {name: "Nephi", age: 29},
                {name: "Enos", age: 34},
                {name: "Tiancum", age: 43},
                {name: "Jacob", age: 27},
                {name: "Nephi", age: 29},
                {name: "Enos", age: 34},
                {name: "Tiancum", age: 43},
                {name: "Jacob", age: 27},
                {name: "Nephi", age: 29},
                {name: "Enos", age: 34},
                {name: "Tiancum", age: 43},
                {name: "Jacob", age: 27},
                {name: "Nephi", age: 29},
                {name: "Enos", age: 34}];

    $scope.tableParams = new ngTableParams({
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
    });

  }]);
