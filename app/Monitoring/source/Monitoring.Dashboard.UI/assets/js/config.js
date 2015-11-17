(function() {
    var app = angular.module("app");

    var config =
    {
        apiUrl : "http://dev.monitoring.web.lightstone.co.za"
    };

    app.config("config", config);

    app.config(["$httpProvider", function ($httpProvider) {
        $httpProvider.url = app.config.apiUrl;
        $httpProvider.defaults.useXDomain = true;
        $httpProvider.defaults.headers.common.Authorization = "Token " + $.cookie("token");
        delete $httpProvider.defaults.headers.common["X-Requested-With"];
    }]);
})