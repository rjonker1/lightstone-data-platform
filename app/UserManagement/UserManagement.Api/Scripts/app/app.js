(function ($) {

    var app = $.sammy('#page-wrapper', function () {

        initializeRoutes(this);
    });

    $(function () {
        app.debug = true;
        app.raise_errors = true;
        app.run('#/');
    });

})(jQuery);