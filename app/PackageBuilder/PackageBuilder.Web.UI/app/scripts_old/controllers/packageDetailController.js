'use strict';

angular.module('packageBuilderwebuiApp')
  .controller('packageDetailCtrl', [ '$scope', '$parse', '$http','GetDataProviderSources', 'PostPackage', function ($scope, $parse, $http, GetDataProviderSources, PostPackage) {

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
        $scope.dataProvsPkg.Package.DataProviders = [];

        GetDataProviderSources.query(function(data){

           var resp = data.response;
              
               for( var res in resp)
               {

                  if (resp.hasOwnProperty(res)) {
                                                                  
                      $scope.dataProvsPkg.Package.DataProviders = resp;
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


        $scope.createPackage = function(packageData) {

          $scope.message = 'Saving data...';

          PostPackage.save({}, packageData, function(data) {

          //var resp = data.msg;

          $scope.alerts = [

            { type: 'success', msg: 'Package: '+$scope.dataProvsPkg.Package.name+' saved successfully !' }
          ];

          $location.path('/data-sources');

          }, function(err){

          $scope.message = "Error saving Data Provider";
          });

        }


        $scope.dataProvs = {};
        $scope.dataProvs.provs = {};
        $scope.dataProvs.provs.prov = {};
        $scope.sum = 0;


    $scope.updatePackageAPIModel = function(providers, fieldName) {


      for (var provs in $scope.dataProvsPkg.Package){

        var provider = $scope.dataProvsPkg.Package[provs];

        for(var i = 0; i < provider.length; i++) {

          for(var p in provider) {


            if(provider.hasOwnProperty(p)) {

              var provFields = provider[p].dataFields; //Fields container for DataProvider


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


    $scope.updateDataProvs = function(fieldName) {

        
        for (var providers in $scope.dataProvsPkg.Package){

        var provider = $scope.dataProvsPkg.Package[providers];

        for(var i = 0; i < provider.length; i++) {

          for(var p in provider) {

            if(provider.hasOwnProperty(p)) {

              var provFields = provider[p].dataFields; //Fields container for DataProvider

              for(var field in provFields) {

                 
                if(provFields[field].isSelected == true && provFields[field].name == fieldName) {

                   // When we parse an AngularJS expression, we get back a function that
                  // will evaluate the given expression in the context of a given $scope.
                  var dp = $parse('{'+field+':false}');
                  var selectedFields = $scope.dataProvs.provs.prov;

                  $scope.updatePackageAPIModel($scope.dataProvsPkg, fieldName);


                  angular.forEach(selectedFields, function(value, key) {

                    (key == fieldName) ? value = false : value = true;

                    $scope.dataProvs.provs.prov[""+key] = value;
                    
                  });

                }

              }
                    
            }

          } //End for-loop provider

        }

      }
    }


       
    $scope.findProvFieldByName = function (providers, fieldName) {


      for (var provs in $scope.dataProvsPkg.Package){

        var provider = $scope.dataProvsPkg.Package[provs];

        for(var i = 0; i < provider.length; i++) {

          for(var p in provider) {

            if(provider.hasOwnProperty(p)) {

                    var provFields = provider[p].dataFields; //Fields container for DataProvider

                    //$scope.test = provFields;

                    for(var field in provFields) {

                        if(provFields[field].name == fieldName)
                        return provFields[field];

                    }
                  }

                } //End for-loop provider

              }

            }

    }


        
    $scope.$watch('dataProvs', function (newValue, oldValue) {


        var provider = newValue.provs.prov;
        var sum = 0;
        for ( var prov in provider ){

           var dataProvList = $scope.dataProvsPkg;
           
           if ( provider[prov] ){
               
               var provPrice = $scope.findProvFieldByName(dataProvList, prov);
               if ( provPrice !== null ){

                   sum += parseFloat(provPrice.price, 10,2);
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