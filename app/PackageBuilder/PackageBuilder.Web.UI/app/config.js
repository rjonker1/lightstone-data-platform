﻿(function () {
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

    var config = {
        appErrorPrefix: '[LSA Error] ', //Configure the exceptionHandler decorator
        docTitle: 'LightstoneAuto: ',
        events: events,
        remoteServiceName: remoteServiceName,
        version: '2.1.0',
        baseUri: "http://localhost:62500",
        apiUri: apiUrl
    };
    
    if (config.apiUri.indexOf("Lightstone.dp.pb.api.url") > -1) {
        config.apiUri = "http://dev.lightstone.packagebuilder.api";
    }

    app.value('config', config); //Global placeholder for config settings
    
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