(function () {
    'use strict';

    var app = angular.module('app');

    // Configure Toastr
    toastr.options.timeOut = 4000;
    toastr.options.positionClass = 'toast-bottom-right';

    // For use with the HotTowel-Angular-Breeze add-on that uses Breeze
    var remoteServiceName = 'breeze/Breeze';

    var events = {
        controllerActivateSuccess: 'controller.activateSuccess',
        spinnerToggle: 'spinner.toggle'
    };

    // used by Octopus Deploy
    var apiUrl = "#{Lightstone.dp.pb.api.url}";
    var ciaAuth = "#{Lightstone.cia.auth}";

    var config = {
        appErrorPrefix: '[LSA Error] ', //Configure the exceptionHandler decorator
        docTitle: 'LightstoneAuto: ',
        events: events,
        remoteServiceName: remoteServiceName,
        version: '2.1.0',
        baseUri: "http://localhost:62500",
        apiUri: apiUrl,
        ciaAuthUri: ciaAuth
    };
    
    if (config.apiUri.indexOf("Lightstone.dp.pb.api.url") > -1) {
        config.apiUri = "http://dev.packagebuilder.api.lightstone.co.za";
    }

    if (config.ciaAuthUri.indexOf("Lightstone.cia.auth") > -1) {
        config.ciaAuthUri = "http://dev.cia.lightstone.co.za/login";
    }

    app.value('config', config); //Global placeholder for config settings
    
    //app.config(['$logProvider', '$httpProvider', function ($logProvider, $httpProvider) {
    //    $httpProvider.defaults.useXDomain = true;
    //    $httpProvider.defaults.headers.common['X-Requested-With'];
    //    $httpProvider.defaults.withCredentials = true;
    //    // turn debugging off/on (no info or warn)
    //    if ($logProvider.debugEnabled) {
    //        $logProvider.debugEnabled(true);
    //    }
    //}]);
    
    app.config(['$httpProvider', function ($httpProvider) {
        //$httpProvider.defaults.withCredentials = true;
        //$httpProvider.defaults.useXDomain = true;
        $httpProvider.defaults.useXDomain = true;
        $httpProvider.defaults.headers.common.Authorization = 'Token ' + $.cookie('token');
        delete $httpProvider.defaults.headers.common['X-Requested-With'];
    }]);
    
    app.config(['$logProvider', function ($logProvider) {
        // turn debugging off/on (no info or warn)
        if ($logProvider.debugEnabled) {
            $logProvider.debugEnabled(true);
        }
    }]);
    
    //#region Configure the common services via commonConfig
    app.config(['commonConfigProvider', function (cfg) {
        cfg.config.controllerActivateSuccessEvent = config.events.controllerActivateSuccess;
        cfg.config.spinnerToggleEvent = config.events.spinnerToggle;
    }]);
    //#endregion
})();