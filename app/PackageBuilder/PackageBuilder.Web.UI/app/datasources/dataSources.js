(function () {
    'use strict';

    angular
        .module('app')
        .controller('dataSources', dataSources);

    dataSources.$inject = ['$scope']; 

    function dataSources($scope) {

        $scope.title = 'dataSources';

        $scope.myData = [
     {
         "firstName": "Cox",
         "lastName": "Carney",
         "company": "Enormo",
         "employed": true
     },
     {
         "firstName": "Lorraine",
         "lastName": "Wise",
         "company": "Comveyer",
         "employed": false
     },
     {
         "firstName": "Nancy",
         "lastName": "Waters",
         "company": "Fuelton",
         "employed": false
     }
        ];



        activate();

        function activate() { }
    }
})();
