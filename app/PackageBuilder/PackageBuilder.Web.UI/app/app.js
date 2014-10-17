(function () {
    'use strict';

    var app = angular.module('app', [
        // Angular modules 
        'ngAnimate',        // animations
        'ngRoute',          // routing
        'ngSanitize',       // sanitizes html bindings (ex: sidebar.js)
        'ngGrid',

        // Custom modules 
        'common',           // common functions, logger, spinner
        'common.bootstrap', // bootstrap dialog wrapper functions
        'apiProviderServices',

        // 3rd Party Modules
        'breeze.angular',    // configures breeze for an angular app
        'breeze.directives', // contains the breeze validation directive (zValidate)
        'ui.bootstrap',       // ui-bootstrap (ex: carousel, pagination, dialog)
        'ui.tree'
    ]);

    // Handle routing errors and success events.
    // Trigger breeze configuration
    app.run(['$route', function ($route) {
        // Include $route to kick start the router.
    }]);
})();