'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:pkgCtrl
 * @description
 * # pkgCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('pkgCtrl', function ($scope, $http) {
    
    $scope.dataProvsPkg = [{
                          'name': 'Loading Data...',
                          'fields': [
                          {
                              'name': 'Loading Data...',
                          }]
                        }];

    $http({
        method: 'GET',
        url: '/DataProviders.json'
        }).success(function(data, status, headers, config) {
            $scope.dataProvsPkg = data;

        }).error(function(data, status, headers, config) {
          
            $scope.dataProvsPkg = [{
                          'name': 'Error Loading Data...',
                          "fields": [
                          {
                              'name': 'Error Loading Data...',
                          }]
                        }];
        });

        $scope.dataPros = {};
        $scope.dataPros.prods = {};
        $scope.dataPros.prods.prod = {};
        $scope.sum = 0;
        
        $scope.$watch('dataPros', function (newValue, oldValue) {
            var findProdById = function (products, id) {
                for(var prods in products){ /*{}*/


                    if (products.hasOwnProperty(prods)) {
                          
                        var attr = products[prods];
                        
                        for (var i = 0; i < attr.length; i++) {        /*[]*/
                                                                        
                                /*for (var props in attr[i].fields) {*/                                             
                                var dps = attr[i].fields;   
                                /*$scope.test = dps[1].id;        */
                                for (var x = 0; x < dps.length; x++) {
                                    

                                     if (dps[x].id == id) {
                                                                     
                                          return dps[x];
                                      } 

                                      /*return null;*/    
                                }

                        }
                     }
                                  
                }         
            };

            var orders = newValue;
               
            var usedProducts = newValue.prods.prod;
            var sum = 0;
            for ( var prop in usedProducts ){

               var dataProvList = $scope.dataProvsPkg;
               var id = prop;
               if ( usedProducts[id] ){
                   
                   var product = findProdById(dataProvList, id);
                   if ( product !== null ){
                       sum += parseInt(product.price, 10);
                   }
               }
            }
            $scope.sum = sum;
        }, true);

    $scope.toggle = function(scope) {
      scope.toggle();
    };

    $scope.moveLastToTheBegginig = function () {
      var a = $scope.data.pop();
      $scope.data.splice(0,0, a);
    };

    $scope.collapseAll = function() {
      $scope.$broadcast('collapseAll');
    };

    $scope.expandAll = function() {
      $scope.$broadcast('expandAll');
    };


  } );

