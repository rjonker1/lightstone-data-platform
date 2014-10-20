(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['common', 'GetDataProvider', 'GetDataProviders',
                            'GetDataProviderSources', 'GetPackages', 'PostDataProvider', datacontext]);

    function datacontext(common, GetDataProvider, GetDataProviders, GetDataProviderSources,
                    GetPackages, PostDataProvider) {

        //Used to convert promises.
        var $q = common.$q;

        var service = {

            getDataProvider: getDataProvider,
            getAllDataProviders: getAllDataProviders,
            getDataProviderSources: getDataProviderSources,
            getAllPackages: getAllPackages,
            editDataProvider: editDataProvider,
            createPackage: createPackage,

            getPeople: getPeople,
            getMessageCount: getMessageCount
          
        };

        return service;

        //GET
        function getDataProvider(_id, _version) {
            
            GetDataProvider.get({ id: _id, version: _version }, function (data) {

                var resp = data.response;

                for (var res in resp) {

                    /*alert(''+res);*/
                    if (resp.hasOwnProperty(res)) {

                        //$scope.dataProvider = resp;
                        return $q.when(resp);
                    }
                } 
            });

            return $q.when("Error loading Data Provider.");
        }

        //GET
        function getAllDataProviders() {

            GetDataProviders.query(function(data) {

                var resp = data.response;

                for (var res in resp) {

                    if (resp.hasOwnProperty(res)) {

                        return $q.when(resp);
                    }
                }

            });

            //When call fails, return mock data as error
            var myData = [
                {
                    "Id": "123",
                    "Name": "Ivid",
                    "Description": "MOCK",
                    "Version": "1"
                }
            ];

            //return $q.when("Error loading Data Providers.");
            return $q.when(myData);
        }

        //GET
        function getDataProviderSources() {

            GetDataProviderSources.query(function(data) {

                var resp = data.response;

                for (var res in resp) {

                    if (resp.hasOwnProperty(res)) {

                        //$scope.dataProvsPkg.Package.DataProviders = resp;
                        return $q.when(resp);
                    }
                }


            });

            return $q.when("Error loading Data Provider Sources.")
        }

        //GET
        function getAllPackages() {

            GetPackages.query(function(data) {

                var resp = data.response;

                for (var res in resp) {

                    if (resp.hasOwnProperty(res)) {

                        return $q.when = resp;
                    }
                }

                $scope.alerts = [
                    { type: 'success', msg: 'Data loaded successfully !' }
                ];

            });        

            return $q.when("Error loading Packages.");
        }

        //POST
        function editDataProvider(_id, packageData) {
            
            PostDataProvider.save({ id: _id }, providerData, function (data) {

                return $q.when('Data Provider Edited!');
            });

            return $q.when("Error editing Data Provider.");
        }

        //POST
        function createPackage(packageData) {

            PostPackage.save({}, packageData, function (data) {

                return $q.when('Package Created!');
            });

            return $q.when("Error editing Package.");
        }

        function getMessageCount() { return $q.when(72); }

        function getPeople() {
            var people = [
                { firstName: 'John', lastName: 'Papa', age: 25, location: 'Florida' },
                { firstName: 'Ward', lastName: 'Bell', age: 31, location: 'California' },
                { firstName: 'Colleen', lastName: 'Jones', age: 21, location: 'New York' },
                { firstName: 'Madelyn', lastName: 'Green', age: 18, location: 'North Dakota' },
                { firstName: 'Ella', lastName: 'Jobs', age: 18, location: 'South Dakota' },
                { firstName: 'Landon', lastName: 'Gates', age: 11, location: 'South Carolina' },
                { firstName: 'Haley', lastName: 'Guthrie', age: 35, location: 'Wyoming' }
            ];

            return $q.when(people);
        };

    }
})();