(function () {
    'use strict';

    angular.module('app').factory('stateRepository', ['common', 'getIndexStateResource', 'postAddStateResource', 'postEditStateResource', stateRepository]);

    function stateRepository(common, getIndexStateResource, postAddStateResource, postEditStateResource) {
        var $q = common.$q;

        var service = {
            getStates: getStates,
            addState: addState,
            updateState: updateState,
        };

        return service;

        function getStates() {
            var deferred = $q.defer();
            getIndexStateResource.query({}, 
                   function (successCallback) {
                        deferred.resolve(successCallback);
                }, function (errorCallback) {
                        deferred.reject(errorCallback);
                });

            return $q.when(deferred.promise);
        }

        function addState(name) {
            var deferred = $q.defer();
            postAddStateResource.save({}, { name: name },
                   function (successCallback) {
                        deferred.resolve(successCallback);
                }, function (errorCallback) {
                        deferred.reject(errorCallback);
                }); 

            return $q.when(deferred.promise);
        }

        function updateState(id, name, alias) {
            var deferred = $q.defer();
            postEditStateResource.save({}, { id: id, name: name, alias: alias },
                   function (successCallback) {
                        deferred.resolve(successCallback);
                }, function (errorCallback) {
                        deferred.reject(errorCallback);
                });

            return $q.when(deferred.promise);
        }
    }
})();