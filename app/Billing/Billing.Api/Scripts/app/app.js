(function ($) {

    var app = $.sammy('.content', function () {

        initializeRoutes(this);
    });

    $(function () {
        app.debug = true;
        app.raise_errors = true;
        app.run('#/');
    });

})(jQuery);