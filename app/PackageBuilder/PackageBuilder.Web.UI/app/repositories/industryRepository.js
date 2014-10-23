(function () {
    'use strict';

    angular.module('app').factory('industryRepository', ['common', 'getIndexIndustryResource', 'postAddIndustryResource', 'postEditIndustryResource', industryRepository]);

    function industryRepository(common, getIndexIndustryResource, postAddIndustryResource, postEditIndustryResource) {
        var $q = common.$q;

        var service = {
            getIndustries: getIndustries,
            addIndustry: addIndustry,
            updateIndustry: updateIndustry,
        };

        return service;

        function getIndustries() {
            var deferred = $q.defer();
            getIndexIndustryResource.query({}, 
                   function (successCallback) {
                        deferred.resolve(successCallback);
                }, function (errorCallback) {
                        deferred.reject(errorCallback);
                });

            return $q.when(deferred.promise);
        }

        function addIndustry(name) {
            var deferred = $q.defer();
            postAddIndustryResource.save({}, { name: name },
                   function (successCallback) {
                        deferred.resolve(successCallback);
                }, function (errorCallback) {
                        deferred.reject(errorCallback);
                }); 

            return $q.when(deferred.promise);
        }

        function updateIndustry(id, name) {
            var deferred = $q.defer();
            postEditIndustryResource.save({}, { id: id, name: name },
                   function (successCallback) {
                        deferred.resolve(successCallback);
                }, function (errorCallback) {
                        deferred.reject(errorCallback);
                });

            return $q.when(deferred.promise);
        }
    }
})();