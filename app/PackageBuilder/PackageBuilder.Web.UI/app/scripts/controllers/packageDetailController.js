'use strict';

/**
 * @ngdoc function
 * @name packageBuilderwebuiApp.controller:pkgCtrl
 * @description
 * # pkgCtrl
 * Controller of the packageBuilderwebuiApp
 */
angular.module('packageBuilderwebuiApp')
  .controller('packageDetailCtrl', function ($scope, $http) {

    $http({
        method: 'GET',
        url: '/DataProviders.json'
        }).success(function(data, status, headers, config) {
            
            $scope.dataProvsPkg = data;

        }).error(function(data, status, headers, config) {
          
         
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

                      $scope.test = provs[p];

                      if (provs.hasOwnProperty(p)) {

                        var provFields = provs[p].dataFields;;    //Fields container for DataProvider
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
                                                                                                                   
                                var dps = attr[i].dataFields;   //Fields container for DataProvider
                               
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


            var orders = newValue;
               
            var usedProducts = newValue.prods.prod;
            var sum = 0;
            for ( var prop in usedProducts ){

               var dataProvList = $scope.dataProvsPkg;
               var id = prop;
               if ( usedProducts[id] ){
                   
                   var product = $scope.findProvFieldByName(dataProvList, id);
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

