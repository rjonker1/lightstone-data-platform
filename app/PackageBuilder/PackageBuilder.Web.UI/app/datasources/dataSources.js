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


        $scope.selectedDatasource = [];

        $scope.gridOptions = {
            data: 'myData',
            selectedItems: $scope.selectedDatasource,
            multiSelect: false,
            enableFiltering: true,
            showFilter: true,
            showGroupPanel: true,
            columnDefs: [
                { field: 'name', displayName: 'Name', filter: { term: '' } },
                { field: 'description', displayName: 'Description' },
                { field: 'owner', displayName: 'Owner' },
                { field: 'created', displayName: 'Created' },
                { field: 'edited', displayName: 'Edited' },
                { field: 'version', displayName: 'Version' },
                { displayName: '', cellTemplate: '<input type="button" name="edit" ng-click="notify(row)" value="Edit" />' }
            ]
        };



        activate();

        function activate() { }
    }
})();
