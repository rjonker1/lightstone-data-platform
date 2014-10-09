'use strict';

angular.module('packageBuilderwebuiApp')
  .controller('packageDetailCtrl', [ '$scope', '$http','GetDataProviderSources', function ($scope, $http, GetDataProviderSources) {

    //MOCK
    /*$http({
        method: 'GET',
        url: '/DataProviders.json'
        }).success(function(data, status, headers, config) {
            
           $scope.dataProvsPkg = data;

        }).error(function(data, status, headers, config) {
          
         
        });*/

        $scope.dataProvsPkg = {}; 
        $scope.dataProvsPkg.Package = {};
        $scope.dataProvsPkg.Package.Providers = [];

        GetDataProviderSources.query(function(data){

           var resp = data.response;
              
               for( var res in resp)
               {

                  if (resp.hasOwnProperty(res)) {
                                                                  
                      $scope.dataProvsPkg.Package.Providers = resp;
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

        $scope.dataPros = {};
        $scope.dataPros.prods = {};
        $scope.dataPros.prods.prod = {};
        $scope.sum = 0;

        $scope.updateAPIModel = function(providers, fieldName) {


          for (var providers in $scope.dataProvsPkg.Package){

            var provider = $scope.dataProvsPkg.Package[providers];

            for(var i = 0; i < provider.length; i++) {

              for(var p in provider) {

                if(provider.hasOwnProperty(p)) {

                        var provFields = provider[p].dataFields; //Fields container for DataProvider

                        $scope.test = provFields;

                        for(var field in provFields) {


                          if(provFields[field].name == fieldName) {

                            if(provFields[field].isSelected == false) {

                              provFields[field].isSelected = true
                            } else {

                              provFields[field].isSelected = false;
                            }
                          }

                        }
                      }

                    } //End for-loop provider

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


  }]);

