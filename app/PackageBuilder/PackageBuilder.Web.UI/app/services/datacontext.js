(function () {
    'use strict';

    var serviceId = 'datacontext';
    angular.module('app').factory(serviceId, ['$http', 'common', 'GetDataProvider', 'GetDataProviders',
                            'GetDataProviderSources', 'GetPackages', 'PostDataProvider', datacontext]);

    function datacontext($http, common, GetDataProvider, GetDataProviders, GetDataProviderSources,
                    GetPackages, PostDataProvider) {

        //Used to convert promises.
        var $q = common.$q;
        var data = {};

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

        //GET *
        function getDataProvider(_id, _version) {

            var deferred = $q.defer();

            $http.get('http://localhost:12257/Package/Get/' + _id + '/' + _version + '').then(function (result) {

                deferred.resolve(result);

            }, function (error) {

                deferred.reject(error);

            });

            return $q.when(deferred.promise);
        }

        //GET *
        function getAllDataProviders() {

            var deferred = $q.defer();

            $http.get('http://localhost:12257/DataProvider').then(function (result) {

                data = result.data;
                deferred.resolve(data);

            }, function (error) {

                deferred.reject(error);

            });

            return $q.when(deferred.promise);
        }

        //GET
        function getDataProviderSources() {

            var deferred = $q.defer();

            $http.get('http://localhost:12257/DataProvider/Get/All').then(function (result) {

                data = result.data;
                deferred.resolve(result);

            }, function (error) {

                deferred.reject(error);

            });

            return $q.when(deferred.promise);
        }

        //GET
        function getAllPackages() {

            var deferred = $q.defer();
            
            $http.get('http://localhost:12257/Packages').then(function (result) {

                data = result.data;
                deferred.resolve(data);

            }, function (error) {

                deferred.reject(error);

            });

            //GetPackages.query().$promise.then(function (result) {

            //    data = result;
            //    console.log(data);
            //    //deferred.resolve(data);

            //}, function (error) {

            //    deferred.reject(error);

            //});

            //console.log('asdasd');
            //console.log(deferred.promise);
            return $q.when(deferred.promise);

        }

        //POST
        function editDataProvider(_id, providerData) {

            var deferred = $q.defer();

            $http.post('http://localhost:12257/DataProvider/Edit/' + _id + '', providerData).then(function(result) {

                deferred.resolve(result);

            }, function(error) {

                deferred.resolve(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function createPackage(packageData) {

            var deferred = $q.defer();

            $http.post('http://localhost:12257/Package/Add', packageData).then(function (result) {

                deferred.resolve(result);

            }, function (error) {

                deferred.resolve(error);
            });

            return $q.when(deferred.promise);

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