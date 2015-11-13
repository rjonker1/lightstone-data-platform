(function () {
    'use strict';

    var serviceId = 'datacontext';
    //angular.module('app').factory(serviceId, ['$http', 'common', 'GetDataProvider', 'GetDataProviders',
    //                        'GetDataProviderSources', 'GetPackages', 'PostDataProvider', datacontext]);

    angular.module('app').factory(serviceId, ['$http', 'common', 'config', datacontext]);

    function datacontext($http, common, config) {
        //function datacontext($http, common, GetDataProvider, GetDataProviders, GetDataProviderSources,
        //            GetPackages, PostDataProvider) {

        //Used to convert promises.
        var $q = common.$q;
        var data = {};

        var service = {
            
            getDataProvider: getDataProvider,
            getAllDataProviders: getAllDataProviders,
            getDataProviderSources: getDataProviderSources,
            getAllPackages: getAllPackages,
            editDataProvider: editDataProvider,
            amendDataProvider: amendDataProvider,
            
            getPackage: getPackage,
            createPackage: createPackage,
            editPackage: editPackage,
            clonePackage: clonePackage,
            deletePackage: deletePackage,
            

            getStates: getStates,
            getIndustries: getIndustries,
            getPackageEventTypes: getPackageEventTypes,
            getRequestFields: getRequestFields,

            getPeople: getPeople,
            getMessageCount: getMessageCount
        };

        return service;

        //GET *
        function getPackage(_id, _version) {
            var deferred = $q.defer();

            $http.get( config.apiUri + '/Packages/' + _id + '/' + _version + '').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET *
        function getDataProvider(_id, _version) {
            var deferred = $q.defer();

            $http.get( config.apiUri + '/DataProviders/' + _id + '/' + _version + '').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET *
        function getAllDataProviders(showAll) {
            var deferred = $q.defer();

            $http.get(config.apiUri + '/DataProviders/' + showAll).then(function (result) {
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

            $http.get( config.apiUri + '/DataProviders/Latest').then(function (result) {
                data = result.data;
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET
        function getAllPackages(showAll) {
            var deferred = $q.defer();
            
            $http.get(config.apiUri + '/Packages/' + showAll).then(function (result) {
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

            $http.put( config.apiUri + '/DataProviders/' + _id + '', providerData).then(function (result) {
                deferred.resolve(result);
            }, function(error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }
        
        function amendDataProvider(_id) {
            var deferred = $q.defer();

            $http.put(config.apiUri + '/DataProviders/' + _id + '/amend').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function editPackage(_id, packageData) {
            var deferred = $q.defer();

            $http.put( config.apiUri + '/Packages/' + _id + '', packageData).then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function createPackage(packageData) {
            var deferred = $q.defer();

            $http.post( config.apiUri + '/Packages', packageData).then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //POST
        function clonePackage(_packageToCloneId, _cloneName) {
            var deferred = $q.defer();

            $http.put( config.apiUri + '/Packages/Clone/' + _packageToCloneId + '/' + _cloneName).then(function (result) {
                deferred.resolve(result);
            }, function(error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }
        
        //POST
        function deletePackage(_id) {
            var deferred = $q.defer();

            $http.delete( config.apiUri + '/Packages/Delete/' + _id + '').then(function (result) {
                deferred.resolve(result);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET
        function getStates() {
            var deferred = $q.defer();

            $http.get( config.apiUri + '/States').then(function (result) {
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

            $http.get( config.apiUri + '/Industries').then(function (result) {
                data = result.data;
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }

        //GET
        function getPackageEventTypes() {
            var deferred = $q.defer();

            $http.get(config.apiUri + '/PackageEventTypes').then(function (result) {
                data = result.data;
                deferred.resolve(data);
            }, function (error) {
                deferred.reject(error);
            });

            return $q.when(deferred.promise);
        }
        
        function getRequestFields() {
            var deferred = $q.defer();

            $http.get(config.apiUri + '/Requests').then(function (result) {
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