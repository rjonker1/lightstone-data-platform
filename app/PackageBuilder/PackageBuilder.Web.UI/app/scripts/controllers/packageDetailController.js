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

        $scope.updateAPIModel = function(providers, fieldName) {

                  for (var providers in $scope.dataProvsPkg){

                    var provs = $scope.dataProvsPkg[providers];

                    for (var i = 0; i < provs.length; i++) {

                      for(var p in provs){

                      if (provs.hasOwnProperty(p)) {

                        var provFields = provs[p].fields;;
                        for (var x = 0; x < provFields.length; x++) {


                          if(provFields[x].name == fieldName) {

                            $scope.test = fieldName;

                            if(provFields[x].isSelected == false) {

                                    provFields[x].isSelected = true
                              } else {

                                    provFields[x].isSelected = false;
                              }
                          
                          }
                        }

                      }
                      }
                    }


              }
            }
       
        $scope.findProvFieldByName = function (providers, fieldName) {
                for(var prov in providers){    /*{}*/


                    if (providers.hasOwnProperty(prov)) {
                          
                        var attr = providers[prov];
                        
                        for (var i = 0; i < attr.length; i++) {        /*[]*/
                                                                        
                                /*for (var props in attr[i].fields) {*/                                             
                                var dps = attr[i].fields;   
                                /*$scope.test = dps[1].id;        */
                                for (var x = 0; x < dps.length; x++) {
                                    

                                     if (dps[x].name == fieldName) {
                                    
                                          return dps[x];
                                      } 

                                      /*return null;*/    
                                }

                        }
                     }
                                  
              }
        }


        
        
        $scope.$watch('dataPros', function (newValue, oldValue) {

            var testFunc =  function() {

                    $scope.test = "Works"
                }

            var orders = newValue;
               
            var usedProducts = newValue.prods.prod;
            var sum = 0;
            for ( var prop in usedProducts ){

               var dataProvList = $scope.dataProvsPkg;
               var id = prop;
               if ( usedProducts[id] ){
                   
                   var product = $scope.findProvFieldByName(dataProvList, id);
                   $scope.test = product;
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

