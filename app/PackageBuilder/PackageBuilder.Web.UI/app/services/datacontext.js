(function () {
    'use strict';

    var serviceId = 'datacontext';
    //angular.module('app').factory(serviceId, ['$http', 'common', 'GetDataProvider', 'GetDataProviders',
    //                        'GetDataProviderSources', 'GetPackages', 'PostDataProvider', datacontext]);

    angular.module('app').factory(serviceId, ['$http', 'common', datacontext]);

    function datacontext($http, common) {
        //function datacontext($http, common, GetDataProvider, GetDataProviders, GetDataProviderSources,
        //            GetPackages, PostDataProvider) {

        //Used to convert promises.
        var $q = common.$q;
        var data = {};

        var service = {
            getPackage: getPackage,
            getDataProvider: getDataProvider,
            getAllDataProviders: getAllDataProviders,
            getDataProviderSources: getDataProviderSources,
            getAllPackages: getAllPackages,
            editDataProvider: editDataProvider,
            editPackage: editPackage,
            createPackage: createPackage,
            clonePackage: clonePackage,
            deletePackage: deletePackage,

            getStates: getStates,
            getIndustries: getIndustries,

            getPeople: getPeople,
            getMessageCount: getMessageCount
        };

        return service;

        //GET *
        function getPackage(_id, _version) {
            var deferred = $q.defer();

            $http.get('http://dev.lightstone.packagebuilder.api/Packages/' + _id + '/' + _version + '').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET *
        function getDataProvider(_id, _version) {
            var deferred = $q.defer();

            $http.get('http://dev.lightstone.packagebuilder.api/DataProviders/' + _id + '/' + _version + '').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET *
        function getAllDataProviders() {
            var deferred = $q.defer();

            $http.get('http://dev.lightstone.packagebuilder.api/DataProviders').then(function (result) {
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

            $http.get('http://dev.lightstone.packagebuilder.api/DataProviders/Latest').then(function (result) {
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
            
            $http.get('http://dev.lightstone.packagebuilder.api/Packages').then(function (result) {
                data = result.data;
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function editDataProvider(_id, providerData) {
            var deferred = $q.defer();

            $http.put('http://dev.lightstone.packagebuilder.api/DataProviders/' + _id + '', providerData).then(function (result) {
                deferred.resolve(result);
            }, function(error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function editPackage(_id, packageData) {
            var deferred = $q.defer();

            $http.put('http://dev.lightstone.packagebuilder.api/Packages/' + _id + '', packageData).then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function createPackage(packageData) {
            var deferred = $q.defer();

            $http.post('http://dev.lightstone.packagebuilder.api/Packages', packageData).then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function clonePackage(_packageToCloneId, _cloneName) {
            var deferred = $q.defer();

            $http.put('http://dev.lightstone.packagebuilder.api/Packages/Clone/' + _packageToCloneId + '/' + _cloneName).then(function(result) {
                deferred.resolve(result);
            }, function(error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }
        
        //POST
        function deletePackage(_id) {
            var deferred = $q.defer();

            $http.delete('http://dev.lightstone.packagebuilder.api/Packages/Delete/' + _id + '').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET
        function getStates() {
            var deferred = $q.defer();

            $http.get('http://dev.lightstone.packagebuilder.api/States').then(function (result) {
                data = result.data;
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET
        function getIndustries() {
            var deferred = $q.defer();

            $http.get('http://dev.lightstone.packagebuilder.api/Industries').then(function (result) {
                data = result.data;
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(error);
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