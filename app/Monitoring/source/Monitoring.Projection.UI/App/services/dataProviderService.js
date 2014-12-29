//app.factory("dataProviderService", function($http, $q) {

//    var serviceBase = "api/dataservice/", factory = {};

//    function buildPagingUri(pageIndex, pageSize) {
//        var uri = "?$top=" + pageSize + "&$skip=" + (pageIndex * pageSize);
//        return uri;
//    }

//    function getPagedResource(resource, pageIndex, pageSize) {
//        resource += (arguments.length === 3) ? buildPagingUri(pageIndex, pageSize) : "";
//        return $http.get(serviceBase + resource).then(function(response) {
//            var data = response.data;
//            return {
//                totalRecords: parseInt(response.headers("X-InlineCount")),
//                results: data
//            }
//        });
//    }

//    factory.getMonitoringFromDataProviders = function(pageIndex, pageSize) {
//        return getPagedResource("dataProviders", pageIndex, pageSize);
//    };
//});

//var factory = app.factory("dataProviderService");
//factory.config([
//    "$http", "$q", function($http, $q) {

//        var serviceBase = "api/dataservice/", factory = {};

//        function buildPagingUri(pageIndex, pageSize) {
//            var uri = "?$top=" + pageSize + "&$skip=" + (pageIndex * pageSize);
//            return uri;
//        }

//        function getPagedResource(resource, pageIndex, pageSize) {
//            resource += (arguments.length === 3) ? buildPagingUri(pageIndex, pageSize) : "";
//            return $http.get(serviceBase + resource).then(function(response) {
//                var data = response.data;
//                return {
//                    totalRecords: parseInt(response.headers("X-InlineCount")),
//                    results: data
//                }
//            });
//        }

//        factory.getMonitoringFromDataProviders = function(pageIndex, pageSize) {
//            return getPagedResource("dataProviders", pageIndex, pageSize);
//        };
//    }
//]);

//var factory = angular.factory("dataProviderService").config(["$http","$q", function($http, $q) {

//        var serviceBase = "api/dataservice/", factory = {};

//        function buildPagingUri(pageIndex, pageSize) {
//            var uri = "?$top=" + pageSize + "&$skip=" + (pageIndex * pageSize);
//            return uri;
//        }

//        function getPagedResource(resource, pageIndex, pageSize) {
//            resource += (arguments.length === 3) ? buildPagingUri(pageIndex, pageSize) : "";
//            return $http.get(serviceBase + resource).then(function(response) {
//                var data = response.data;
//                return {
//                    totalRecords: parseInt(response.headers("X-InlineCount")),
//                    results: data
//                }
//            });
//        }

//        factory.getMonitoringFromDataProviders = function(pageIndex, pageSize) {
//            return getPagedResource("dataProviders", pageIndex, pageSize);
//        };
//    }
//])